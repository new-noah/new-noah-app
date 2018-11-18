// itelenkov
// /Users/itelenkov/Projects/PNOAH/PNOAH/Models
using System;
using PNOAH.Services;
namespace PNOAH.Models
{
    public class AnimalModel
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public ContractModel Contract { get; set; }
        public string Url
        {
            get => NOAHConst.BASE_SERVER + NOAHConst.GET_IMAGE + this.Uri;
        }

        //TODO: Move to ViewModels

        public string KindPerson { get;  set; } = "Kind Person";
        public string TakeCare { get; set; } = "Take Care";

        public string AboutAnimal { get; set; } = "An endangered species is a species which has been categorized as very likely to become extinct. Endangered (EN), as categorized by the International Union for Conservation of Nature (IUCN) Red List, is the second most severe conservation status for wild populations in the IUCN's schema after Critically Endangered (CR).";
    }
}
