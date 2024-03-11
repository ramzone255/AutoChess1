using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractWork
{
    public class TablesRep
    {
        SQLiteConnection database;

        public TablesRep(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<ContractStatus>();
            database.CreateTable<TypeOfContract>();
            database.CreateTable<Contract>();
			database.CreateTable<Users>();
        }
		// Методы для таблицы Типы договоров
		public IEnumerable<TypeOfContract> GetItemsType()
		{
			return database.Table<TypeOfContract>().ToList();
		}
		public TypeOfContract GetItemType(int id)
		{
			return database.Get<TypeOfContract>(id);
		}
		public int DeleteItemType(int id)
		{
			return database.Delete<TypeOfContract>(id);
		}
		public int SaveItemType(TypeOfContract item)
		{
			if (item.Id != 0)
			{
				database.Update(item);
				return item.Id;
			}
			else
			{
				return database.Insert(item);
			}
		}

		// Методы для таблицы Статусы договоров
		public IEnumerable<ContractStatus> GetItemsStatus()
		{
			return database.Table<ContractStatus>().ToList();
		}
		public ContractStatus GetItemStatus(int id)
		{
			return database.Get<ContractStatus>(id);
		}
		public int DeleteItemStatus(int id)
		{
			return database.Delete<ContractStatus>(id);
		}
		public int SaveItemStatus(ContractStatus item)
		{
			if (item.Id != 0)
			{
				database.Update(item);
				return item.Id;
			}
			else
			{
				return database.Insert(item);
			}
		}

		// Методы для таблицы Договоры
		public IEnumerable<Contract> GetItemsContract()
		{
			return database.Table<Contract>().ToList();
		}
		public Contract GetItemContract(int id)
		{
			return database.Get<Contract>(id);
		}
		public int DeleteItemContract(int id)
		{
			return database.Delete<Contract>(id);
		}
		public int SaveItemContract(Contract item)
		{
			if (item.Code != 0)
			{
				database.Update(item);
				return item.Code;
			}
			else
			{
				return database.Insert(item);
			}
		}

		// Методы для таблицы Пользователи
		public Users CreateNewUser(string log, string pass, string pass2)
		{
			try
			{
                Users users = new Users
                {
                    Log = log,
                    Pass = pass,
					Pass2 = pass2
                };
                database.Insert(users);
                return users;
            }
			catch (Exception ex)
			{
				throw new Exception($"{ex.Message}");
			}
		}
		public Users SignIn(string lg, string ps)
		{
			try
			{
				var user = database.Table<Users>().Where(x => (x.Log == lg) && x.Pass == ps).First();
				return user;
			}
			catch (Exception ex)
			{
				throw new Exception($"{ex.Message}");
			}
		}
	}
}
