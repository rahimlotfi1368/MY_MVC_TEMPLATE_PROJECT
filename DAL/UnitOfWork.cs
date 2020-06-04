using System.Linq;
namespace DAL
{
    public class UnitOfWork: object, IUnitOfWork
    {
        //**************************************************************
        protected Models.DatabaseContext DatabaseContext { get; set; }
        public UnitOfWork(Models.DatabaseContext databaseContext)
        {
            if (databaseContext==null)
            {
                databaseContext = new Models.DatabaseContext();
            }

            DatabaseContext = databaseContext;
        }
        //**************************************************************
                

        //**************************************************************
        //private RoleUserManager.IUnitOfWork roleUserManagerUnitOfWork;

        //public RoleUserManager.IUnitOfWork RoleUserManagerUnitOfWork
        //{
        //    get
        //    {
        //        if (roleUserManagerUnitOfWork == null)
        //        {
        //            roleUserManagerUnitOfWork =
        //                        new RoleUserManager.UnitOfWork(DatabaseContext);
        //        }

        //        return (roleUserManagerUnitOfWork);
        //    }

        //}

        //************************************************************** 
    }
}
