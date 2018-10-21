using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ECommerce.Models
{
    public class EditBudgetView
    {
        public int BudgetId { get; set; }

        [Display(Name = "Compañia")]
        public string Company { get; set; }

        [Display(Name = "Cliente")]
        public string Customer { get; set; }

        [Display(Name = "Proyecto")]
        public string Project { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentarios")]
        public string Remarks { get; set; }

        public List<BudgetDetail> DetailsSc01 { get; set; }
        public List<BudgetDetail> DetailsSc02 { get; set; }
        public List<BudgetDetail> DetailsSc03 { get; set; }
        public List<BudgetDetail> DetailsSc04 { get; set; }
        public List<BudgetDetail> DetailsSc05 { get; set; }
        public List<BudgetDetail> DetailsSc06 { get; set; }
        public List<BudgetDetail> DetailsSc07 { get; set; }
        public List<BudgetDetail> DetailsSc08 { get; set; }
        public List<BudgetDetail> DetailsSc09 { get; set; }
        public List<BudgetDetail> DetailsSc10 { get; set; }
        public List<BudgetDetail> DetailsSc11 { get; set; }
        public List<BudgetDetail> DetailsSc12 { get; set; }
        public List<BudgetDetail> DetailsSc13 { get; set; }
        public List<BudgetDetail> DetailsSc14 { get; set; }
        public List<BudgetDetail> DetailsSc15 { get; set; }
        public List<BudgetDetail> DetailsSc16 { get; set; }
        public List<BudgetDetail> DetailsSc17 { get; set; }
        public List<BudgetDetail> DetailsSc18 { get; set; }
        public List<BudgetDetail> DetailsSc19 { get; set; }
        public List<BudgetDetail> DetailsSc20 { get; set; }
        public List<BudgetDetail> DetailsSc21 { get; set; }
        public List<BudgetDetail> DetailsSc22 { get; set; }
        public List<BudgetDetail> DetailsSc23 { get; set; }
        public List<BudgetDetail> DetailsSc24 { get; set; }
        public List<BudgetDetail> DetailsSc25 { get; set; }
        public List<BudgetDetail> DetailsSc26 { get; set; }
        public List<BudgetDetail> DetailsSc27 { get; set; }
        public List<BudgetDetail> DetailsSc28 { get; set; }
        public List<BudgetDetail> DetailsSc29 { get; set; }
        public List<BudgetDetail> DetailsSc30 { get; set; }
        public List<BudgetDetail> DetailsSc31 { get; set; }
        public List<BudgetDetail> DetailsSc32 { get; set; }
        public List<BudgetDetail> DetailsSc33 { get; set; }
        public List<BudgetDetail> DetailsSc34 { get; set; }
        public List<BudgetDetail> DetailsSc35 { get; set; }
        public List<BudgetDetail> DetailsSc36 { get; set; }
        public List<BudgetDetail> DetailsSc37 { get; set; }
        public List<BudgetDetail> DetailsSc38 { get; set; }
        public List<BudgetDetail> DetailsSc39 { get; set; }
        public List<BudgetDetail> DetailsSc40 { get; set; }
        public List<BudgetDetail> DetailsSc41 { get; set; }
        public List<BudgetDetail> DetailsSc42 { get; set; }
        public List<BudgetDetail> DetailsSc43 { get; set; }
        public List<BudgetDetail> DetailsSc44 { get; set; }
        public List<BudgetDetail> DetailsSc45 { get; set; }
        public List<BudgetDetail> DetailsSc46 { get; set; }
        public List<BudgetDetail> DetailsSc47 { get; set; }
        public List<BudgetDetail> DetailsSc48 { get; set; }
        public List<BudgetDetail> DetailsSc49 { get; set; }
        public List<BudgetDetail> DetailsSc50 { get; set; }
        public List<BudgetDetail> DetailsSc51 { get; set; }
        public List<BudgetDetail> DetailsSc52 { get; set; }
        public List<BudgetDetail> DetailsSc53 { get; set; }
        public List<BudgetDetail> DetailsSc54 { get; set; }


        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal01 { get { return DetailsSc01 == null ? 0 : DetailsSc01.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal02 { get { return DetailsSc02 == null ? 0 : DetailsSc02.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal03 { get { return DetailsSc03 == null ? 0 : DetailsSc03.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal04 { get { return DetailsSc04 == null ? 0 : DetailsSc04.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal05 { get { return DetailsSc05 == null ? 0 : DetailsSc05.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal06 { get { return DetailsSc06 == null ? 0 : DetailsSc06.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal07 { get { return DetailsSc07 == null ? 0 : DetailsSc07.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal08 { get { return DetailsSc08 == null ? 0 : DetailsSc08.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal09 { get { return DetailsSc09 == null ? 0 : DetailsSc09.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal10 { get { return DetailsSc10 == null ? 0 : DetailsSc10.Sum(d => d.PartialPrice); } }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal11 { get { return DetailsSc11 == null ? 0 : DetailsSc11.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal12 { get { return DetailsSc12 == null ? 0 : DetailsSc12.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal13 { get { return DetailsSc13 == null ? 0 : DetailsSc13.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal14 { get { return DetailsSc14 == null ? 0 : DetailsSc14.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal15 { get { return DetailsSc15 == null ? 0 : DetailsSc15.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal16 { get { return DetailsSc16 == null ? 0 : DetailsSc16.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal17 { get { return DetailsSc17 == null ? 0 : DetailsSc17.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal18 { get { return DetailsSc18 == null ? 0 : DetailsSc18.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal19 { get { return DetailsSc19 == null ? 0 : DetailsSc19.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal20 { get { return DetailsSc20 == null ? 0 : DetailsSc20.Sum(d => d.PartialPrice); } }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal21 { get { return DetailsSc21 == null ? 0 : DetailsSc21.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal22 { get { return DetailsSc22 == null ? 0 : DetailsSc22.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal23 { get { return DetailsSc23 == null ? 0 : DetailsSc23.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal24 { get { return DetailsSc24 == null ? 0 : DetailsSc24.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal25 { get { return DetailsSc25 == null ? 0 : DetailsSc25.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal26 { get { return DetailsSc26 == null ? 0 : DetailsSc26.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal27 { get { return DetailsSc27 == null ? 0 : DetailsSc27.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal28 { get { return DetailsSc28 == null ? 0 : DetailsSc28.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal29 { get { return DetailsSc29 == null ? 0 : DetailsSc29.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal30 { get { return DetailsSc30 == null ? 0 : DetailsSc30.Sum(d => d.PartialPrice); } }


        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal31 { get { return DetailsSc31 == null ? 0 : DetailsSc31.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal32 { get { return DetailsSc32 == null ? 0 : DetailsSc32.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal33 { get { return DetailsSc33 == null ? 0 : DetailsSc33.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal34 { get { return DetailsSc34 == null ? 0 : DetailsSc34.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal35 { get { return DetailsSc35 == null ? 0 : DetailsSc35.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal36 { get { return DetailsSc36 == null ? 0 : DetailsSc36.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal37 { get { return DetailsSc37 == null ? 0 : DetailsSc37.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal38 { get { return DetailsSc38 == null ? 0 : DetailsSc38.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal39 { get { return DetailsSc39 == null ? 0 : DetailsSc39.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal40 { get { return DetailsSc40 == null ? 0 : DetailsSc40.Sum(d => d.PartialPrice); } }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal41 { get { return DetailsSc41 == null ? 0 : DetailsSc41.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal42 { get { return DetailsSc42 == null ? 0 : DetailsSc42.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal43 { get { return DetailsSc43 == null ? 0 : DetailsSc43.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal44 { get { return DetailsSc44 == null ? 0 : DetailsSc44.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal45 { get { return DetailsSc45 == null ? 0 : DetailsSc45.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal46 { get { return DetailsSc46 == null ? 0 : DetailsSc46.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal47 { get { return DetailsSc47 == null ? 0 : DetailsSc47.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal48 { get { return DetailsSc48 == null ? 0 : DetailsSc48.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal49 { get { return DetailsSc49 == null ? 0 : DetailsSc49.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal50 { get { return DetailsSc50 == null ? 0 : DetailsSc50.Sum(d => d.PartialPrice); } }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal51 { get { return DetailsSc51 == null ? 0 : DetailsSc51.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal52 { get { return DetailsSc52 == null ? 0 : DetailsSc52.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal53 { get { return DetailsSc53 == null ? 0 : DetailsSc53.Sum(d => d.PartialPrice); } }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SubTotal54 { get { return DetailsSc54 == null ? 0 : DetailsSc54.Sum(d => d.PartialPrice); } }


        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal TotalButget
        {
            get
            {
                return SubTotal01 + SubTotal02 + SubTotal03 + SubTotal04 + SubTotal05 + SubTotal06 + SubTotal07 + SubTotal08 + SubTotal09 + SubTotal10 +
                       SubTotal11 + SubTotal12 + SubTotal13 + SubTotal14 + SubTotal15 + SubTotal16 + SubTotal17 + SubTotal18 + SubTotal19 + SubTotal20 +
                       SubTotal21 + SubTotal22 + SubTotal23 + SubTotal24 + SubTotal25 + SubTotal26 + SubTotal27 + SubTotal28 + SubTotal29 + SubTotal30 +
                       SubTotal31 + SubTotal32 + SubTotal33 + SubTotal34 + SubTotal35 + SubTotal36 + SubTotal37 + SubTotal38 + SubTotal39 + SubTotal40 +
                       SubTotal41 + SubTotal42 + SubTotal43 + SubTotal44 + SubTotal45 + SubTotal46 + SubTotal47 + SubTotal48 + SubTotal49 + SubTotal50 +
                       SubTotal51 + SubTotal52 + SubTotal53 + SubTotal54
;
            }
        }
    }
}