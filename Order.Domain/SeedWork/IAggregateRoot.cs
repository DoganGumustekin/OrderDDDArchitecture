using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.SeedWork
{
    public interface IAggregateRoot
    {
        //bu bizim için sadece markap interface olacak yani sadece işaretlemek için kullanacağım.
        //içerisinde herhangi bir şey olmasına gerek yok. Core daki IEntity gibi.
        //biz sadece oluşturduğumuz model ve classları işaretleyebilmek için kullanacağız.
        //bu bir aggregate root tur biri bu classın içine girdiğinde aggregate root olduğunu anlasın diye.
    }
}
