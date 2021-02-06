using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic Repository Design Pattern
    //generic constraint = cenerik kısıt (where T:class)
    //class : referans tip olabilir
    //IEntity : T ya IEntity olabilir yada IEntity den implemente edilmiş bi nesne olabilir
    //IEntity yi devre dışı bırakmak istiyoruz bunun için new anahtar kelimesi, new'lenebilir oldugunu gösteriyor

    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//delege yapısı LINQ ile birlikte gelmekte, çağırırken LINX expressionu yazabiliriz
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
