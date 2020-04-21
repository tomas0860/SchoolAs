using System;

namespace SchoolAs.DAL.Extensions
{
    public static class ValidatorHelper
    {
        public static bool IsValid(this Person item)
        {
            bool isValid = true;

            // Check obligatories fields.
            if (String.IsNullOrEmpty(item.Name) || String.IsNullOrEmpty(item.LastName) || String.IsNullOrEmpty(item.Id))
            {
                isValid = false;
            }

            return isValid;
        }

        public static bool IsValid(this School item)
        {
            bool isValid = true;

            // Check obligatories fields.
            if (String.IsNullOrEmpty(item.Name) || String.IsNullOrEmpty(item.City) || String.IsNullOrEmpty(item.Phone) || String.IsNullOrEmpty(item.Email))
            {
                isValid = false;
            }

            return isValid;
        }
    }
}
