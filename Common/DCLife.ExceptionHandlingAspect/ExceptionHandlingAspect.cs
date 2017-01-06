using Spring.Aop.Framework;
using Spring.Aop.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCLife.Exceptions
{

    public class ExceptionHandlingAspect
    {
        #region prop
        private static LogArgumentsThrowsAdvice logArgumentsThrowsAdvice = new LogArgumentsThrowsAdvice();
        internal LogArgumentsThrowsAdvice LogArgumentsThrowsAdvice
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {

            }
        }

        #endregion

        /// <summary>
        /// Gets the proxy by applying throw advices. The methods identified by the
        /// <code>methodRE</code> regular expression will be intercepted by the throw advice.
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="methodRE">regular expression will be intercepted by the throw advice</param>
        /// <returns></returns>
        public static object GetProxy(object target, string methodRE)
        {
            SdkRegularExpressionMethodPointcut reMethodPointcut = new SdkRegularExpressionMethodPointcut(methodRE);
            ProxyFactory proxyFactory = new ProxyFactory(target);
            DefaultPointcutAdvisor exceptionHandlingAdvisor =
                new DefaultPointcutAdvisor(logArgumentsThrowsAdvice);
            proxyFactory.AddAdvisor(exceptionHandlingAdvisor);
            return proxyFactory.GetProxy();
        }

    }
}
