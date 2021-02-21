using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //class ın attributlerini onu
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            //metodun attributlerini oku
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

            //listeye ekle
            classAttributes.AddRange(methodAttributes);
            //otomatik olarak sistemdeti tüm metotları logla
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            //çalışmalarını önceik değerlerine göre sırala
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
