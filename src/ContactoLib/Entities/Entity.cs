using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace Contacto.Lib
{
    public class Entity : ObjectBase
    {
        #region Member variables

        protected Guid guid;
        protected int entityType;
        protected int type;
        protected string number;
        private string displayName;
        private Guid ownerGuid;
        private bool system;
        private bool hidden;
        private bool readOnly;
        private bool closed;
        private bool @internal;
        private bool deleted;
        private bool primary;
        private int version;
        private DateTime dateCreated;
        private DateTime dateAccessed;
        private DateTime dateModified;
        private DateTime dateDeleted;
        private Guid userCreated;
        private Guid userAccessed;
        private Guid userModified;
        private Guid userDeleted;
        private string tag;

        protected List<Address> addresses;
        protected List<Identifier> identifiers;
        protected List<Date> dates;
        protected List<Link> links;
        protected List<Category> categories;
        protected List<Document> documents;

        protected bool detailsLoaded;

        #endregion
        #region Properties

        public Guid Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        public int EntityType
        {
            get { return entityType; }
            set { entityType = value; }
        }

        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        public Guid OwnerGuid
        {
            get { return ownerGuid; }
            set { ownerGuid = value; }
        }

        public bool System
        {
            get { return system; }
            set { system = value; }
        }

        public bool Hidden
        {
            get { return hidden; }
            set { hidden = value; }
        }

        public bool ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }

        public bool Closed
        {
            get { return closed; }
            set { closed = value; }
        }

        public bool Internal
        {
            get { return @internal; }
            set { @internal = value; }
        }

        public bool Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }

        public bool Primary
        {
            get { return primary; }
            set { primary = value; }
        }

        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public DateTime DateAccessed
        {
            get { return dateAccessed; }
            set { dateAccessed = value; }
        }

        public DateTime DateModified
        {
            get { return dateModified; }
            set { dateModified = value; }
        }

        public DateTime DateDeleted
        {
            get { return dateDeleted; }
            set { dateDeleted = value; }
        }

        public Guid UserCreated
        {
            get { return userCreated; }
            set { userCreated = value; }
        }

        public Guid UserAccessed
        {
            get { return userAccessed; }
            set { userAccessed = value; }
        }

        public Guid UserModified
        {
            get { return userModified; }
            set { userModified = value; }
        }

        public Guid UserDeleted
        {
            get { return userDeleted; }
            set { userDeleted = value; }
        }

        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public List<Address> Addresses
        {
            get { return addresses; }
        }

        public List<Identifier> Identifiers
        {
            get { return identifiers; }
        }

        public List<Date> Dates
        {
            get { return dates; }
        }

        public List<Link> Links
        {
            get { return links; }
        }

        public List<Category> Categories
        {
            get { return categories; }
        }

        public List<Document> Documents
        {
            get { return documents; }
        }

        #endregion
        #region Costructors

        public Entity()
            : base()
        {
            InitializeMembers();
        }

        public Entity(Context context)
            : base(context)
        {
            InitializeMembers();
        }

        public Entity(Entity old)
            : base(old)
        {
            CopyMembers(old);
        }

        #endregion
        #region Initializers

        private void InitializeMembers()
        {
            this.guid = Guid.Empty;
            this.entityType = EntityTypes.Unknown;
            this.type = 0;
            this.number = string.Empty;
            this.displayName = string.Empty;
            this.ownerGuid = Guid.Empty;
            this.system = false;
            this.hidden = false;
            this.readOnly = false;
            this.closed = false;
            this.@internal = false;
            this.deleted = false;
            this.primary = false;
            this.version = 0;
            this.dateCreated = DateTime.Now;
            this.dateAccessed = DateTime.Now;
            this.dateModified = DateTime.Now;
            this.dateDeleted = DateTime.MinValue;
            this.userCreated = Guid.Empty;
            this.userAccessed = Guid.Empty;
            this.userModified = Guid.Empty;
            this.userDeleted = Guid.Empty;
            this.tag = null;

            this.addresses = null;
            this.identifiers = null;
            this.dates = null;
            this.links = null;
            this.categories = null;

            detailsLoaded = false;
        }

        private void CopyMembers(Entity old)
        {
            this.guid = old.guid;
            this.entityType = old.entityType;
            this.type = old.type;
            this.number = old.number;
            this.displayName = old.displayName;
            this.ownerGuid = old.ownerGuid;
            this.system = old.system;
            this.hidden = old.hidden;
            this.readOnly = old.readOnly;
            this.closed = old.closed;
            this.@internal = old.@internal;
            this.deleted = old.deleted;
            this.primary = old.primary;
            this.version = old.version;
            this.dateCreated = old.dateCreated;
            this.dateAccessed = old.dateAccessed;
            this.dateModified = old.dateModified;
            this.dateDeleted = old.dateDeleted;
            this.userCreated = old.userCreated;
            this.userAccessed = old.userAccessed;
            this.userModified = old.userModified;
            this.userDeleted = old.userDeleted;
            this.tag = old.tag;

            this.addresses = old.addresses;
            this.identifiers = old.identifiers;
            this.dates = old.dates;
            this.links = old.links;
            this.categories = old.categories;
        }

        internal virtual int LoadFromReader(SqlDataReader dr)
        {
            int o = -1;

            this.guid = dr.GetGuid(++o);
            this.entityType = dr.GetInt32(++o);
            this.type = dr.GetInt32(++o);
            this.number = dr.GetString(++o);
            this.displayName = dr.GetString(++o);
            this.ownerGuid = dr.GetGuid(++o);
            this.system = dr.GetBoolean(++o);
            this.hidden = dr.GetBoolean(++o);
            this.readOnly = dr.GetBoolean(++o);
            this.closed = dr.GetBoolean(++o);
            this.@internal = dr.GetBoolean(++o);
            this.deleted = dr.GetBoolean(++o);
            this.primary = dr.GetBoolean(++o);
            this.version = dr.GetInt32(++o);
            this.dateCreated = dr.GetDateTime(++o);
            this.dateAccessed = dr.GetDateTime(++o);
            this.dateModified = dr.IsDBNull(++o) ? DateTime.MinValue : dr.GetDateTime(o);
            this.dateDeleted = dr.IsDBNull(++o) ? DateTime.MinValue : dr.GetDateTime(o);
            this.userCreated = dr.GetGuid(++o);
            this.userAccessed = dr.GetGuid(++o);
            this.userModified = dr.IsDBNull(++o) ? Guid.Empty : dr.GetGuid(o);
            this.userDeleted = dr.IsDBNull(++o) ? Guid.Empty : dr.GetGuid(o);
            this.tag = dr.IsDBNull(++o) ? null : dr.GetString(o);

            return o;
        }

        #endregion
        #region Database IO functions

        public virtual void NewEntity(Entity parentEntity)
        {
            GenerateRequiredAddresses();
            GenerateRequiredIdentifiers();
            GenerateRequiredDates();
            GenerateRequiredCategories();
            GenerateRequiredLinks();
        }

        public void Save()
        {
            Save(false);
        }

        public void Save(bool forceOverwrite)
        {
            if (guid == Guid.Empty)
            {
                guid = Guid.NewGuid();
                Create();
            }
            else
            {
                if (!forceOverwrite)
                {
                    if (!CheckVersion())
                    {
                        throw new InvalidVersionException();
                    }
                }
                Modify();
            }
        }

        internal bool CheckVersion()
        {
            string sql = "spCheckEntityVersion";

            using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
            {
                cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
                cmd.Parameters.Add("@Version", SqlDbType.Int).Value = version;
                cmd.Parameters.Add("RETVAL", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                cmd.ExecuteNonQuery();

                return ((int)cmd.Parameters["RETVAL"].Value) == 1;
            }
        }

        protected virtual void Create()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.CreateEntity);

                string sql = "spCreateEntity";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);
                    cmd.ExecuteNonQuery();
                }

                UpdateStatistics(0, Operations.Create);

                SaveRequiredAddresses();
                SaveRequiredIdentifiers();
                SaveRequiredDates();
                SaveRequiredLinks();
                SaveRequiredCategories();

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CreateEntityFailed, ex);
            }
        }

        protected virtual void Modify()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.ModifyEntity);

                string sql = "spModifyEntity";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    AppendCreateModifyCommandParameters(cmd);
                    cmd.ExecuteNonQuery();

                    UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Modify);
                }

                SaveRequiredAddresses();
                SaveRequiredIdentifiers();
                SaveRequiredDates();
                SaveRequiredLinks();
                SaveRequiredCategories();

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.ModifyEntityFailed, ex);
            }
        }

        private void AppendCreateModifyCommandParameters(SqlCommand cmd)
        {
            cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
            cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
            cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("@EntityType", SqlDbType.Int).Value = entityType;
            cmd.Parameters.Add("@Type", SqlDbType.Int).Value = type;
            cmd.Parameters.Add("@Number", SqlDbType.NVarChar, 50).Value = number;
            cmd.Parameters.Add("@DisplayName", SqlDbType.NVarChar, 50).Value = displayName;
            cmd.Parameters.Add("@System", SqlDbType.Bit).Value = system;
            cmd.Parameters.Add("@Hidden", SqlDbType.Bit).Value = hidden;
            cmd.Parameters.Add("@ReadOnly", SqlDbType.Bit).Value = readOnly;
            cmd.Parameters.Add("@Closed", SqlDbType.Bit).Value = closed;
            cmd.Parameters.Add("@Internal", SqlDbType.Bit).Value = @internal;
            cmd.Parameters.Add("@Primary", SqlDbType.Bit).Value = primary;
            cmd.Parameters.Add("@Tag", SqlDbType.NText).Value = tag == null ? DBNull.Value : (object)tag;
        }

        internal void UpdateStatistics(int version, Operations op)
        {
            this.version = version;

            switch (op)
            {
                case Operations.Create:
                    dateCreated = dateModified = dateAccessed = DateTime.Now;
                    userModified = userAccessed = ownerGuid = context.UserGuid;
                    break;
                case Operations.Modify:
                    dateModified = dateAccessed = DateTime.Now;
                    userModified = userAccessed = context.UserGuid;
                    break;
                case Operations.Delete:
                    deleted = true;
                    dateDeleted = DateTime.Now;
                    userDeleted = context.UserGuid;
                    break;
                case Operations.Close:
                    closed = true;
                    break;
                case Operations.Open:
                    closed = false;
                    break;
            }
        }

        public virtual void Load()
        {
            throw new NotImplementedException();
        }

        public virtual void LoadDetails()
        {
            throw new NotImplementedException();
        }

        public bool CanModify()
        {
            return (!readOnly && !closed && !deleted && !hidden);
        }

        public bool CanDelete()
        {
            return (!system && !deleted && !hidden);
        }

        public bool CanClose()
        {
            return (!readOnly && !closed && !deleted && !hidden);
        }

        public bool CanOpen()
        {
            return (!readOnly && closed && !deleted && !hidden);
        }

        public void Delete(bool forceDelete)
        {
            if (!forceDelete)
            {
                if (!CheckVersion())
                {
                    throw new InvalidVersionException();
                }
            }
            Delete();
        }

        private void Delete()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.DeleteEntity);

                string sql = "spDeleteEntity";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
                    cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Delete);
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.DeleteEntityFailed, ex);
            }
        }

        public void Recover()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.RecoverEntity);

                string sql = "spRecoverEntity";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;

                    cmd.ExecuteNonQuery();
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.RecoverEntityFailed, ex);
            }
        }

        public void Close(bool forceClose)
        {
            if (!forceClose)
            {
                if (!CheckVersion())
                {
                    throw new InvalidVersionException();
                }
            }
            Close();
        }

        private void Close()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.CloseEntity);

                string sql = "spCloseEntity";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
                    cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Close);
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.CloseEntityFailed, ex);
            }
        }

        public void Open(bool forceOpen)
        {
            if (!forceOpen)
            {
                if (!CheckVersion())
                {
                    throw new InvalidVersionException();
                }
            }
            Open();
        }

        public void Open()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.OpenEntity);

                string sql = "spOpenEntity";
                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;
                    cmd.Parameters.Add("@Version", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    UpdateStatistics((int)cmd.Parameters["@Version"].Value, Operations.Open);
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.OpenEntityFailed, ex);
            }
        }

        public virtual IEnumerable<Entity> CheckDuplicates()
        {
            yield break;
        }

        #endregion
        #region Address functions

        public void LoadAddresses()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadAddresses);
                if (addresses == null)
                    addresses = new List<Address>();
                else
                    addresses.Clear();

                string sql = "spQueryAddresses";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Address a = new Address(this);
                            a.LoadFromReader(dr);
                            a.EntityType = entityType + EntityTypes.Address;

                            addresses.Add(a);
                        }

                        dr.Close();
                    }
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                addresses = null;
                throw new DBIOException(DBIOMessages.LoadAddressesFailed, ex);
            }
        }

        public void GenerateRequiredAddresses()
        {
            if (addresses == null)
                addresses = new List<Address>();
            else
                addresses.Clear();

            foreach (TypeDescription t in
                context.SchemaManager.GetTypeDescriptions(entityType + EntityTypes.Address))
            {
                if (t.Required)
                {
                    Address a = new Address(this);
                    a.Type = t.Id;
                    a.EntityType = entityType + EntityTypes.Address;
                    addresses.Add(a);
                }
            }
        }

        public void SaveRequiredAddresses()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.SaveRequiredAddresses);
                if (addresses != null)
                    foreach (Address a in addresses)
                        if (a.TypeDescription.Required)
                        {
                            a.Context = this.context;
                            a.Save();
                        }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.SaveRequiredAddressesFailed, ex);
            }
        }

        public Address GetAddress(int type)
        {
            foreach (Address a in addresses)
                if (a.Type == type)
                    return a;

            return null;
        }

        #endregion
        #region Identifier functions

        public void LoadIdentifiers()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadIdentifiers);
                if (identifiers == null)
                    identifiers = new List<Identifier>();
                else
                    identifiers.Clear();

                string sql = "spQueryIdentifiers";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Identifier i = new Identifier(this);
                            i.LoadFromReader(dr);
                            i.EntityType = entityType + EntityTypes.Identifier;
                            identifiers.Add(i);
                        }

                        dr.Close();
                    }
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                identifiers = null;
                throw new DBIOException(DBIOMessages.LoadIdentifiersFailed, ex);
            }
        }

        public void GenerateRequiredIdentifiers()
        {
            if (identifiers == null)
                identifiers = new List<Identifier>();
            else
                identifiers.Clear();

            foreach (TypeDescription t in
                context.SchemaManager.GetTypeDescriptions(entityType + EntityTypes.Identifier))
            {
                if (t.Required)
                {
                    Identifier i = new Identifier(this);
                    i.Type = t.Id;
                    i.EntityType = entityType + EntityTypes.Identifier;
                    identifiers.Add(i);
                }
            }
        }

        public void SaveRequiredIdentifiers()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.SaveRequiredIdentifiers);
                if (identifiers != null)
                    foreach (Identifier i in identifiers)
                        if (i.TypeDescription.Required)
                        {
                            i.Context = this.context;
                            i.Save();
                        }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.SaveRequiredIdentifiersFailed, ex);
            }
        }

        public Identifier GetIdentifier(int type)
        {
            foreach (Identifier i in identifiers)
                if (i.Type == type)
                    return i;

            return null;
        }

        #endregion
        #region Date functions

        public void LoadDates()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadDates);
                if (dates == null)
                    dates = new List<Date>();
                else
                    dates.Clear();

                string sql = "spQueryDates";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Date d = new Date(this);
                            d.LoadFromReader(dr);
                            d.EntityType = entityType + EntityTypes.Date;
                            dates.Add(d);
                        }

                        dr.Close();
                    }
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                dates = null;
                throw new DBIOException(DBIOMessages.LoadDatesFailed, ex);
            }
        }

        public void GenerateRequiredDates()
        {
            if (dates == null)
                dates = new List<Date>();
            else
                dates.Clear();

            foreach (TypeDescription t in
                context.SchemaManager.GetTypeDescriptions(entityType + EntityTypes.Date))
            {
                if (t.Required)
                {
                    Date d = new Date(this);
                    d.Type = t.Id;
                    d.EntityType = entityType + EntityTypes.Date;
                    dates.Add(d);
                }
            }
        }

        public void SaveRequiredDates()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.SaveRequiredDates);
                if (dates != null)
                    foreach (Date d in dates)
                        if (d.TypeDescription.Required)
                        {
                            d.Context = this.context;
                            d.Save();
                        }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.SaveRequiredDatesFailed, ex);
            }
        }

        public Date GetDate(int type)
        {
            foreach (Date d in dates)
                if (d.Type == type)
                    return d;

            return null;
        }

        #endregion
        #region Link functions

        public void LoadLinks()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadLinks);

                if (links == null)
                    links = new List<Link>();
                else
                    links.Clear();

                string sql = "spQueryLinks";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Link link = new Link(this);
                            link.LoadFromReader(dr);
                            link.EntityType = entityType + EntityTypes.Link;
                            links.Add(link);
                        }

                        dr.Close();
                    }
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                links = null;
                throw new DBIOException(DBIOMessages.LoadLinksFailed, ex);
            }
        }

        public void GenerateRequiredLinks()
        {
            if (links == null)
                links = new List<Link>();
            else
                links.Clear();

            foreach (TypeDescription t in
                context.SchemaManager.GetTypeDescriptions(entityType + EntityTypes.Link))
            {
                if (t.Required)
                {
                    Link link = new Link(this);
                    link.Type = t.Id;
                    link.EntityType = entityType + EntityTypes.Link;
                    links.Add(link);
                }
            }
        }

        public void SaveRequiredLinks()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.SaveRequiredLinks);

                if (links != null)
                    foreach (Link link in links)
                        if (link.TypeDescription.Required)
                        {
                            link.Context = this.context;
                            link.Save();
                        }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.SaveRequiredLinksFailed, ex);
            }
        }

        public Link GetLink(int type)
        {
            foreach (Link link in links)
                if (link.Type == type)
                    return link;

            return null;
        }

        #endregion
        #region Category functions

        public void LoadCategories()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.LoadCategories);
                if (categories == null)
                    categories = new List<Category>();
                else
                    categories.Clear();

                string sql = "spQueryCategories";

                using (SqlCommand cmd = CreateStoredProcedureCommand(sql))
                {
                    cmd.Parameters.Add("@UserGUID", SqlDbType.UniqueIdentifier).Value = context.UserGuid;
                    cmd.Parameters.Add("@GUID", SqlDbType.UniqueIdentifier).Value = guid;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Category cat = new Category(this);
                            cat.LoadFromReader(dr);
                            cat.EntityType = entityType + EntityTypes.Category;
                            categories.Add(cat);
                        }

                        dr.Close();
                    }
                }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                categories = null;
                throw new DBIOException(DBIOMessages.LoadCategoriesFailed, ex);
            }
        }

        public void GenerateRequiredCategories()
        {
            if (categories == null)
                categories = new List<Category>();
            else
                categories.Clear();

            foreach (TypeDescription t in
                context.SchemaManager.GetTypeDescriptions(entityType + EntityTypes.Category))
            {
                if (t.Required)
                {
                    Category cat = new Category(this);
                    cat.Type = t.Id;
                    cat.EntityType = entityType + EntityTypes.Category;
                    categories.Add(cat);
                }
            }
        }

        public void SaveRequiredCategories()
        {
            try
            {
                LogEntry log = new LogEntry(context, this, LogOperations.SaveRequiredCategories);
                if (categories != null)
                    foreach (Category cat in categories)
                        if (cat.TypeDescription.Required)
                        {
                            cat.Context = this.context;
                            cat.Save();
                        }

                log.WriteOkEntry();
            }
            catch (System.Exception ex)
            {
                throw new DBIOException(DBIOMessages.SaveRequiredCategoriesFailed, ex);
            }
        }

        public Category GetCategory(int type)
        {
            foreach (Category cat in categories)
                if (cat.Type == type)
                    return cat;

            return null;
        }

        protected string GetFieldCategory(int categoryType, out Color backColor, out Color foreColor)
        {
            Category c = GetCategory(categoryType);

            if (Context.SchemaManager.CategoryDescriptions[entityType][categoryType].ContainsKey(c.Value))
            {
                CategoryDescription cd = Context.SchemaManager.CategoryDescriptions[entityType][categoryType][c.Value];

                backColor = cd.BackColor;
                foreColor = cd.ForeColor;
            }
            else
            {
                backColor = SystemColors.Window;
                foreColor = SystemColors.WindowText;
            }

            return c.DisplayText;
        }

        #endregion
        #region Document functions

        public virtual void LoadDocuments()
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Formatters

        public virtual string[] GetDisplayTextAlternates()
        {
            throw new NotImplementedException();
        }

        public virtual string GetClipboardString()
        {
            throw new NotImplementedException();
        }

        public string GetFieldFormatted(string field)
        {
            Color backColor, foreColor;

            return GetFieldFormatted(field, out backColor, out foreColor);
        }

        public virtual string GetFieldFormatted(string field, out Color backColor, out Color foreColor)
        {
            string res = string.Empty;
            backColor = SystemColors.Window;
            foreColor = SystemColors.WindowText;

            switch (field)
            {
                case "Number":
                    res = number;
                    break;
                case "DisplayName":
                    res = displayName;
                    break;
                case "EntityType":
                    res = context.SchemaManager.GetTypeDescription(entityType, 0).Description;
                    break;
                case "Type":
                    res = context.SchemaManager.GetTypeDescription(entityType, type).Description;
                    break;
                case "Owner":
                    res = Util.UserName(context.SchemaManager.GetUser(ownerGuid));
                    break;
                case "Version":
                    res = version.ToString();
                    break;
                case "System":
                    res = FormatBoolean(system);
                    break;
                case "Hidden":
                    res = FormatBoolean(hidden);
                    break;
                case "ReadOnly":
                    res = FormatBoolean(readOnly);
                    break;
                case "Closed":
                    res = FormatBoolean(closed);
                    break;
                case "Internal":
                    res = FormatBoolean(@internal);
                    break;
                case "Deleted":
                    res = FormatBoolean(deleted);
                    break;
                case "Primary":
                    res = FormatBoolean(primary);
                    break;
                case "DateCreated":
                    res = dateCreated.ToString();
                    break;
                case "DateAccessed":
                    res = dateAccessed.ToString();
                    break;
                case "DateModified":
                    res = dateModified.ToString();
                    break;
                case "DateDeleted":
                    res = dateCreated.ToString();
                    break;
                case "UserCreated":
                    res = Util.UserName(context.SchemaManager.GetUser(userCreated));
                    break;
                case "UserAccessed":
                    res = Util.UserName(context.SchemaManager.GetUser(userAccessed));
                    break;
                case "UserModified":
                    res = Util.UserName(context.SchemaManager.GetUser(userModified));
                    break;
                case "UserDeleted":
                    if (deleted)
                        res = Util.UserName(context.SchemaManager.GetUser(userDeleted));
                    else
                        res = "(nem volt)";
                    break;
            }
            return res;
        }

        private string FormatBoolean(bool value)
        {
            return value ? "igen" : "nem";
        }

        #endregion
    }
}
