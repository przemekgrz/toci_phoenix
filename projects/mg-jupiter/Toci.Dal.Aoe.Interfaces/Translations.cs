//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Toci.Dal.Aoe.Interfaces
{
    using System;
    using System.Collections.Generic;
    
    public partial class Translations
    {
        public long Id { get; set; }
        public Nullable<long> IdLanguages { get; set; }
        public Nullable<long> IdPhrases { get; set; }
        public string Translation { get; set; }
    
        public virtual Languages Languages { get; set; }
        public virtual Phrases Phrases { get; set; }
    }
}
