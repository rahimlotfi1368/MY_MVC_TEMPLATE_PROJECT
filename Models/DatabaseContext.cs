namespace Models
{
    public class DatabaseContext : System.Data.Entity.DbContext
    {
        static DatabaseContext()
        {
			// فقط به درد برنامه‌نويسان، آن هم در زمان پياده‌سازی می‌خورد
			//System.Data.Entity.Database.SetInitializer
			//	(new System.Data.Entity.DropCreateDatabaseAlways<DatabaseContext>());

			// فقط به درد برنامه‌نويسان، آن هم در زمان پياده‌سازی می ‌خورد
			System.Data.Entity.Database.SetInitializer
				(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>());

			// به درد مشتری می‌خورد
			//System.Data.Entity.Database.SetInitializer
			//	(new System.Data.Entity.CreateDatabaseIfNotExists<DatabaseContext>());
		}
		public DatabaseContext():base()
		{

		}
		//به تعداد موجودیت های موجود در مدل
		

	}
}
