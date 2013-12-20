using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Contacto.Lib
{
    public class SchemaManager : ObjectBase
    {
        #region Member variables

        private List<CategoryDescription> categoryDescriptions;
        private SortedDictionary<int, SortedDictionary<int, TypeDescription>> typeDescriptions;
        private List<User> users;
        private bool loaded = false;

        #endregion
        #region Properties

        public IEnumerable<User> Users
        {
            get { return users; }
        }

        public bool Loaded
        {
            get { return loaded; }
        }

        #endregion
        #region Costructors

        public SchemaManager(Context context)
            : base(context)
        {
            InitializeMembers();
        }

        #endregion
        #region Initializer functions

        private void InitializeMembers()
        {
            this.typeDescriptions = null;
            this.categoryDescriptions = null;
        }

        #endregion
        #region Database query functions

        private IEnumerable<TypeDescription> LoadTypeDescriptions()
        {
            LogEntry log = new LogEntry(context, null, LogOperations.LoadTypeDescriptions);
            SqlDataReader dr = null;

            try
            {

                string sql = "spQueryTypeDescriptions";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;

                    dr = cmd.ExecuteReader();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.LoadTypeDescriptionsFailed, ex);
            }

            if (dr != null)
            {
                while (dr.Read())
                {
                    TypeDescription t = new TypeDescription();
                    t.LoadFromReader(dr);
                    yield return t;
                }

                dr.Close();
                dr.Dispose();

                log.WriteOkEntry();
            }
        }

        private IEnumerable<CategoryDescription> LoadCategoryDescriptions()
        {
            LogEntry log = new LogEntry(context, null, LogOperations.LoadCategoryDescriptions);
            SqlDataReader dr = null;

            try
            {
                string sql = "spQueryCategoryDescriptions";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;

                    dr = cmd.ExecuteReader();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.LoadCategoryDescriptionsFailed, ex);
            }

            if (dr != null)
            {
                while (dr.Read())
                {
                    CategoryDescription t = new CategoryDescription();
                    t.LoadFromReader(dr);
                    yield return t;
                }

                dr.Close();
                dr.Dispose();

                log.WriteOkEntry();
            }
        }

        private IEnumerable<User> LoadUsers()
        {
            LogEntry log = new LogEntry(context, null, LogOperations.LoadUsers);
            SqlDataReader dr = null;

            try
            {
                string sql = "spQueryUsers";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;

                    dr = cmd.ExecuteReader();
                }
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.LoadUsersFailed, ex);
            }

            if (dr != null)
            {
                while (dr.Read())
                {
                    User user = new User();
                    user.LoadFromReader(dr);
                    yield return user;
                }

                dr.Close();
                dr.Dispose();

                log.WriteOkEntry();
            }
        }

        #endregion

        public void LoadSchema()
        {
            try
            {
                LogEntry log = new LogEntry(context, null, LogOperations.LoadSchema);

                this.typeDescriptions = new SortedDictionary<int, SortedDictionary<int, TypeDescription>>();

                foreach (TypeDescription t in LoadTypeDescriptions())
                {
                    SortedDictionary<int, TypeDescription> x = null;
                    if (typeDescriptions.ContainsKey(t.EntityType))
                        x = typeDescriptions[t.EntityType];

                    if (x == null)
                    {
                        x = new SortedDictionary<int, TypeDescription>();
                        typeDescriptions.Add(t.EntityType, x);
                    }

                    x.Add(t.Id, t);
                }

                this.categoryDescriptions = new List<CategoryDescription>(LoadCategoryDescriptions());

                users = new List<User>(LoadUsers());

                log.WriteOkEntry();

                loaded = true;
            }
            catch (System.Exception ex)
            {
                loaded = false;
                throw new DBIOException(DBIOMessages.ErrorLoadingSchema, ex);
            }
        }

        public TypeDescription GetTypeDescription(int entityType, int type)
        {
            if (typeDescriptions[entityType].ContainsKey(type))
                return typeDescriptions[entityType][type];
            else return
                null;
        }

        public IEnumerable<TypeDescription> GetAllTypeDescriptions()
        {
            foreach (int entityType in typeDescriptions.Keys)
                foreach (TypeDescription t in typeDescriptions[entityType].Values)
                    if (t.Id != 0) yield return t;
        }

        public IEnumerable<TypeDescription> GetTypeDescriptions(int entityType)
        {
            if (typeDescriptions.ContainsKey(entityType))
            {
                foreach (TypeDescription t in typeDescriptions[entityType].Values)
                    if (t.Id != 0)
                        yield return t;
            }
            else
            {
                yield break;
            }
        }

        public int GetNextTypeId(int entityType)
        {
            if (typeDescriptions.ContainsKey(entityType))
            {
                int i = 0;
                foreach (TypeDescription t in typeDescriptions[entityType].Values)
                    if (t.Id != 0)
                        i = Math.Max(i, t.Id);

                return i + 1;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<TypeDescription> GetAllEntityDescriptions()
        {
            foreach (int entityType in typeDescriptions.Keys)
                if (typeDescriptions[entityType].ContainsKey(0))
                    yield return typeDescriptions[entityType][0];
        }

        public TypeDescription GetEntityDescription(int entityType)
        {
            return typeDescriptions[entityType][0];
        }

        public int GetNextCategoryDescriptionId(int entityType, int categoryType)
        {
            int i = 0;
            foreach (CategoryDescription c in categoryDescriptions)
                if (c.EntityType == entityType && c.Type == categoryType)
                    i++;

            return i + 1;
        }

        public IEnumerable<CategoryDescription> GetCategoryDescriptions(int entityType, int categoryType)
        {
            foreach (CategoryDescription c in categoryDescriptions)
                if (c.EntityType == entityType && c.Type == categoryType)
                    yield return c;
        }

        public User GetUser(Guid guid)
        {
            foreach (User u in users)
                if (u.Guid == guid)
                    return u;

            return null;
        }
    }
}
