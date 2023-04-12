using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain
{
    internal static class Consts
    {
        public const string Error_EmailNormalization = "An error ocurred verifying email structure.";
        public const string Error_UserDuplicated = "The user is duplicated.";
        public const string UserTypeNormal = "Normal";
        public const string UserTypeSuperUser = "SuperUser";
        public const string UserTypePremium = "Premium";
    }
}
