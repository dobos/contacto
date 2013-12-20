using System;
using System.Collections.Generic;
using System.Text;

namespace Contacto.Lib
{
    public enum Operations
    {
        Create,
        Modify,
        Delete,
        Close,
        Open
    }

    public static class EntityTypes
    {
        public const int Unknown = 0;
        public const int Company = 10000;
        public const int Person = 20000;
        public const int Document = 30000;
        public const int Blob = 40000;
        public const int Folder = 50000;
        public const int Reminder = 60000;

        public const int Identifier = 1;
        public const int Address = 2;
        public const int Category = 3;
        public const int Date = 4;
        public const int Link = 5;

        public static int GetSubtype(int entityType)
        {
            //
            return entityType - (entityType / 10000) * 10000;
        }
    }

    public enum CompanyTypes
    {
        Unknown
    }

    public enum AddressTypes
    {
        Primary = 1
    }

    public enum IdentifierTypes : int
    {
        PrimaryPhone = 1,
        PrimaryEmail = 2,
        Phone = 3,
        Email = 4,
        WebAddress = 5,
        PrimaryFax = 6,
        PrimaryMobile = 7,
        Fax = 8,
        Mobile = 9,
        MsnId = 10,
        SkypeId = 11,
    }

    public enum LinkTypes
    {
        PersonCompanyLink = 1,
        FolderCompanyLink = 1,
        FolderPersonLink = 2,
        FolderUserLink = 3,
        DocumentFromCompanyLink = 1,
        DocumentFromPersonLink = 2,
        DocumentToCompanyLink = 3,
        DocumentToPersonLink = 4,
        DocumentFolderLink = 5,
        BlobToDocumentLink = 1
    }

    public enum DateTypes
    {
        Primary = 1,
        FolderOrderDate = 1,
        FolderDueDate = 2,
    }

    public enum CategoryTypes
    {
        Primary = 1,
        PrimaryIndustry = 2,
        Industry = 3,
        DocumentDirection = 3,
        Brand = 4,
        Classification = 4,
    }

    public enum PersonTypes
    {
        Unknown,
        Contact,
        User
    }

    public enum Genders
    {
        Male,
        Female
    }

    public enum DocumentTypes
    {
        Unknown = 0
    }

    public enum DocumentDirections
    {
        Unknown = 0,
        Internal = 1,
        Outbound = 2,
        Inbound = 3
    }

    public enum BlobTypes
    {
        Unknown,
        Document,
        Note
    }

    public enum FolderTypes
    {
        Unknown,
        Worksheet
    }

    public enum CheckOutMode
    {
        ReadOnly,
        Edit,
        Print
    }
}
