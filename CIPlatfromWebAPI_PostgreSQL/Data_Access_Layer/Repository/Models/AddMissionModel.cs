using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository.Models
{
    public class AddMissionModel
    {
        public string MissionTitle { get; set; }
        public string MissionDescription { get; set; }
        public string MissionOrganisationName { get; set; }
        public string MissionOrganisationDetail { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }

        // Change StartDate and EndDate data types
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        public string MissionType { get; set; }
        public int? TotalSheets { get; set; }
        [Column(TypeName = "date")]
        public DateTime? RegistrationDeadLine { get; set; }
        public string MissionThemeId { get; set; }
        public string MissionSkillId { get; set; }
        public string MissionImages { get; set; }
        public string MissionDocuments { get; set; }
        public string MissionAvilability { get; set; }
        public string MissionVideoUrl { get; set; }
        /*[NotMapped]
        public string MissionStatus { get; set; }
        [NotMapped]
        public string MissionApplyStatus { get; set; }
        [NotMapped]
        public string MissionApproveStatus { get; set; }
        [NotMapped]
        public string MissionDateStatus { get; set; }
        [NotMapped]
        public string MissionDeadLineStatus { get; set; }
        [NotMapped]
        public string MissionFavouriteStatus { get; set; }
        [NotMapped]
        public int Rating { get; set; }*/
    }
}
