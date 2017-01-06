using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Shop.Core;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Data.Extensions;
using Shop.Core.Collections;
using Shop.Core.Extensions;
namespace Shop.Services.Common
{
    public partial class GenericAttributeService : IGenericAttributeService
    {
        #region Constants

        private const string GENERICATTRIBUTE_KEY = "SmartStore.genericattribute.{0}-{1}";
        private const string GENERICATTRIBUTE_PATTERN_KEY = "SmartStore.genericattribute.";
        #endregion

        #region Fields

        private readonly IRepositoryAsync<GenericAttribute> _genericAttributeRepository;
        //private readonly IRequestCache _requestCache;
        //private readonly IEventPublisher _eventPublisher;
        private readonly IRepository<Order> _orderRepository;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="requestCache">Cache manager</param>
        /// <param name="genericAttributeRepository">Generic attribute repository</param>
        /// <param name="eventPublisher">Event published</param>
        /// <param name="orderRepository">Order repository</param>
        public GenericAttributeService(//IRequestCache requestCache,
            IRepositoryAsync<GenericAttribute> genericAttributeRepository,
            //IEventPublisher eventPublisher,
            IRepositoryAsync<Order> orderRepository)
        {
          //  this._requestCache = requestCache;
            this._genericAttributeRepository = genericAttributeRepository;
           // this._eventPublisher = eventPublisher;
            this._orderRepository = orderRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes an attribute
        /// </summary>
        /// <param name="attribute">Attribute</param>
        public virtual void DeleteAttribute(GenericAttribute attribute)
        {
            if (attribute == null)
                throw new ArgumentNullException("attribute");

            int entityId = attribute.EntityId;
            string keyGroup = attribute.KeyGroup;

            _genericAttributeRepository.Delete(attribute);

            //cache
           // _requestCache.RemoveByPattern(GENERICATTRIBUTE_PATTERN_KEY);

            //event notifications
          //  _eventPublisher.EntityDeleted(attribute);

            if (keyGroup.IsCaseInsensitiveEqual("Order") && entityId != 0)
            {
                var order = _orderRepository.Find(entityId);
              //  _eventPublisher.PublishOrderUpdated(order);
            }
        }

        /// <summary>
        /// Gets an attribute
        /// </summary>
        /// <param name="attributeId">Attribute identifier</param>
        /// <returns>An attribute</returns>
        public virtual GenericAttribute GetAttributeById(int attributeId)
        {
            if (attributeId == 0)
                return null;

            var attribute = _genericAttributeRepository.Find(attributeId);
            return attribute;
        }

        /// <summary>
        /// Inserts an attribute
        /// </summary>
        /// <param name="attribute">attribute</param>
        public virtual void InsertAttribute(GenericAttribute attribute)
        {
            if (attribute == null)
                throw new ArgumentNullException("attribute");

            _genericAttributeRepository.Insert(attribute);

            //cache
           /// _requestCache.RemoveByPattern(GENERICATTRIBUTE_PATTERN_KEY);

            //event notifications
           // _eventPublisher.EntityInserted(attribute);

            if (attribute.KeyGroup.IsCaseInsensitiveEqual("Order") && attribute.EntityId != 0)
            {
                var order = _orderRepository.Find(attribute.EntityId);
               // _eventPublisher.PublishOrderUpdated(order);
            }
        }

        /// <summary>
        /// Updates the attribute
        /// </summary>
        /// <param name="attribute">Attribute</param>
        public virtual void UpdateAttribute(GenericAttribute attribute)
        {
            if (attribute == null)
                throw new ArgumentNullException("attribute");

            _genericAttributeRepository.Update(attribute);

            //cache
            //_requestCache.RemoveByPattern(GENERICATTRIBUTE_PATTERN_KEY);

            //event notifications
            //_eventPublisher.EntityUpdated(attribute);

            if (attribute.KeyGroup.IsCaseInsensitiveEqual("Order") && attribute.EntityId != 0)
            {
                var order = _orderRepository.Find(attribute.EntityId);
              //  _eventPublisher.PublishOrderUpdated(order);
            }
        }

        /// <summary>
        /// Get attributes
        /// </summary>
        /// <param name="entityId">Entity identifier</param>
        /// <param name="keyGroup">Key group</param>
        /// <returns>Get attributes</returns>
        public virtual IList<GenericAttribute> GetAttributesForEntity(int entityId, string keyGroup)
        {
            string key = string.Format(GENERICATTRIBUTE_KEY, entityId, keyGroup);
            //return _requestCache.Get(key, () =>
            //{
                var attributes =  _genericAttributeRepository.Queryable()
                                .Where(x=>x.EntityId==entityId&& x.KeyGroup==keyGroup).ToList();
                            //where ga.EntityId == entityId &&
                            //ga.KeyGroup == keyGroup
                            //select ga;
              //  var attributes = query.ToList();
                return attributes;
          //  });
        }

        public virtual Multimap<int, GenericAttribute> GetAttributesForEntity(int[] entityIds, string keyGroup)
        {
            Guard.ArgumentNotNull(() => entityIds);

            var query = _genericAttributeRepository.Queryable()
                .Where(x => entityIds.Contains(x.EntityId) && x.KeyGroup == keyGroup);

            var map = query
                .ToList()
                .ToMultimap(x => x.EntityId, x => x);

            return map;
        }

        /// <summary>
        /// Get queryable attributes
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="keyGroup">The key group</param>
        /// <returns>Queryable attributes</returns>
        public virtual IQueryable<GenericAttribute> GetAttributes(string key, string keyGroup)
        {
            return _genericAttributeRepository.Queryable().Where(x => x.KeyGroup == keyGroup && x.Key == key); 
        }

        /// <summary>
        /// Save attribute value
        /// </summary>
        /// <typeparam name="TPropType">Property type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <param name="storeId">Store identifier; pass 0 if this attribute will be available for all stores</param>
        public virtual void SaveAttribute<TPropType>(Entity entity, string key, TPropType value, int storeId = 0)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            SaveAttribute(entity.Id, key, entity.GetUnproxiedEntityType().Name, value, storeId);
        }

        public virtual void SaveAttribute<TPropType>(int entityId, string key, string keyGroup, TPropType value, int storeId = 0)
        {
            Guard.NotZero(entityId, "entityId");

            var props = GetAttributesForEntity(entityId, keyGroup)
                 .Where(x => x.StoreId == storeId)
                 .ToList();

            var prop = props.FirstOrDefault(ga =>
                ga.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)); // should be culture invariant

            string valueStr = value.Convert<string>();

            if (prop != null)
            {
                if (string.IsNullOrWhiteSpace(valueStr))
                {
                    // delete
                    DeleteAttribute(prop);
                }
                else
                {
                    // update
                    prop.Value = valueStr;
                    UpdateAttribute(prop);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(valueStr))
                {
                    // insert
                    prop = new GenericAttribute
                    {
                        EntityId = entityId,
                        Key = key,
                        KeyGroup = keyGroup,
                        Value = valueStr,
                        StoreId = storeId
                    };
                    InsertAttribute(prop);
                }
            }
        }

        #endregion
    }
}
