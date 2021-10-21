using Core.Entities;
using Core.Subcriptions.Abstract;
using Core.Subcriptions.SqlTableDependency;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class SubscriptionModule : ICoreModule
    {
        Type[] _subcriptionTableList;
        Type _subscriptionType;

        public SubscriptionModule(Type subscriptionType, Type[] subcriptionTableList)
        {
            _subcriptionTableList = subcriptionTableList;
            if (subscriptionType.IsAssignableTo(typeof(IDatabaseSubscription)))
            {
                _subscriptionType = subscriptionType;
            }
        }

        public void Load(IServiceCollection serviceCollection)
        {
            foreach (Type type in _subcriptionTableList)
            {
                Type genericSubscription = _subscriptionType.MakeGenericType(type);
                //ConstructorInfo subscriptionConstructor = genericSubscription.
                //                                GetConstructor(BindingFlags.Instance | BindingFlags.Public,
                //                                null, 
                //                                new Type[] { },
                //                                null);
                
                serviceCollection.AddSingleton(genericSubscription);
            }
                
             
        }
    }
}
