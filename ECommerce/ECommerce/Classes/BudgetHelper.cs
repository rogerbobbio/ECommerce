using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Models;

namespace ECommerce.Classes
{
    public class BudgetHelper : IDisposable
    {
        private static ECommerceContext db = new ECommerceContext();

        public static List<BudgetDetail> GetBudgetDetails(string subCategoryCode)
        {
            var budgetDetails = db.BudgetDetails.Where(odt => odt.BudgetId == -1).ToList();

            switch (subCategoryCode)
            {
                case "SC01":
                    //OBRAS PRELIMINARES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA01",
                        Category = "OBRAS PRELIMINARES",
                        SubcategoryCode = "SC01",
                        Subcategory = "OBRAS PRELIMINARES",
                        Description = "OFICINAS, ALMACENES, VESTIDORES, COMEDOR",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA01",
                        Category = "OBRAS PRELIMINARES",
                        SubcategoryCode = "SC01",
                        Subcategory = "OBRAS PRELIMINARES",
                        Description = "TRAZO DURANTE LA EJECUCION DE LA OBRA",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA01",
                        Category = "OBRAS PRELIMINARES",
                        SubcategoryCode = "SC01",
                        Subcategory = "OBRAS PRELIMINARES",
                        Description = "AGUA PARA LA CONSTRUCCIÓN",
                        Unity = "vje",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA01",
                        Category = "OBRAS PRELIMINARES",
                        SubcategoryCode = "SC01",
                        Subcategory = "OBRAS PRELIMINARES",
                        Description = "INSTALACION PROVISIONAL DE ENERGIA ELECTRICA",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA01",
                        Category = "OBRAS PRELIMINARES",
                        SubcategoryCode = "SC01",
                        Subcategory = "OBRAS PRELIMINARES",
                        Description = "LIMPIEZA DURANTE LA OBRA",
                        Unity = "glb",
                    });
                    break;
                case "SC02":
                    //SEGURIDAD Y SALUD ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA02",
                        Category = "SEGURIDAD Y SALUD",
                        SubcategoryCode = "SC02",
                        Subcategory = "SEGURIDAD Y SALUD",
                        Description = "ELABORACION, IMPLEMENTACION Y ADMINISTRACION DEL PLAN DE SEGURIDAD Y SALUD EN EL TRABAJO",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA02",
                        Category = "SEGURIDAD Y SALUD",
                        SubcategoryCode = "SC02",
                        Subcategory = "SEGURIDAD Y SALUD",
                        Description = "EQUIPOS DE PROTECCION INDIVIDUAL",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA02",
                        Category = "SEGURIDAD Y SALUD",
                        SubcategoryCode = "SC02",
                        Subcategory = "SEGURIDAD Y SALUD",
                        Description = "EQUIPOS DE PROTECCION COLECTIVA",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA02",
                        Category = "SEGURIDAD Y SALUD",
                        SubcategoryCode = "SC02",
                        Subcategory = "SEGURIDAD Y SALUD",
                        Description = "SEÑALIZACION TEMPORAL DE SEGURIDAD",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA02",
                        Category = "SEGURIDAD Y SALUD",
                        SubcategoryCode = "SC02",
                        Subcategory = "SEGURIDAD Y SALUD",
                        Description = "MITIGACIÓN AMBIENTAL",
                        Unity = "glb",
                    });
                    break;
                case "SC03":
                    //TRANSPORTE VERTICAL Y HORIZONTAL DE MATERIALES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA03",
                        Category = "TRANSPORTE VERTICAL Y HORIZONTAL DE MATERIALES",
                        SubcategoryCode = "SC03",
                        Subcategory = "TRANSPORTE VERTICAL Y HORIZONTAL DE MATERIALES",
                        Description = "TRANSPORTE VERTICAL Y HORIZONTAL DE MATERIALES EN OBRA",
                        Unity = "glb",
                    });
                    break;
                case "SC04":
                    //DEMOLICIONES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA04",
                        Category = "DEMOLICIONES",
                        SubcategoryCode = "SC04",
                        Subcategory = "DEMOLICIONES",
                        Description = "PEGAMENTO EPOXICO P/UNION DE CONCRETO NUEVO-VIEJO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA04",
                        Category = "DEMOLICIONES",
                        SubcategoryCode = "SC04",
                        Subcategory = "DEMOLICIONES",
                        Description = "PICADO DE ESTRUCTURA VIEJA",
                        Unity = "m2",
                    });
                    break;
                case "SC05":
                    //MOVIMIENTO DE TIERRAS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA05",
                        Category = "MOVIMIENTO DE TIERRAS",
                        SubcategoryCode = "SC05",
                        Subcategory = "MOVIMIENTO DE TIERRAS",
                        Description = "LIMPIEZA DE TERRENO MANUAL",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA05",
                        Category = "MOVIMIENTO DE TIERRAS",
                        SubcategoryCode = "SC05",
                        Subcategory = "MOVIMIENTO DE TIERRAS",
                        Description = "RELLENO COMPACTADO CON MATERIAL DE PRESTAMO",
                        Unity = "m3",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA05",
                        Category = "MOVIMIENTO DE TIERRAS",
                        SubcategoryCode = "SC05",
                        Subcategory = "MOVIMIENTO DE TIERRAS",
                        Description = "NIVELACION INTERIOR Y APISONADO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA05",
                        Category = "MOVIMIENTO DE TIERRAS",
                        SubcategoryCode = "SC05",
                        Subcategory = "MOVIMIENTO DE TIERRAS",
                        Description = "ELIMINACION DE MATERIAL EXCEDENTE",
                        Unity = "m3",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA05",
                        Category = "MOVIMIENTO DE TIERRAS",
                        SubcategoryCode = "SC05",
                        Subcategory = "MOVIMIENTO DE TIERRAS",
                        Description = "ACARREO DE MATERIAL",
                        Unity = "glb",
                    });
                    break;
                case "SC06":
                    //CONCRETO SIMPLE ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA06",
                        Category = "CONCRETO SIMPLE",
                        SubcategoryCode = "SC06",
                        Subcategory = "CONCRETO SIMPLE",
                        Description = "ENCOFRADO Y DESENCOFRADO DE RAMPA",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA06",
                        Category = "CONCRETO SIMPLE",
                        SubcategoryCode = "SC06",
                        Subcategory = "CONCRETO SIMPLE",
                        Description = "CONCRETO SIMPLE  f'c=175 kg/cm2 PARA RAMPA",
                        Unity = "m3",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA06",
                        Category = "CONCRETO SIMPLE",
                        SubcategoryCode = "SC06",
                        Subcategory = "CONCRETO SIMPLE",
                        Description = "VEREDA DE CONCRETO A = 2.00 h = 0.15 f'c=175 kg/cm2",
                        Unity = "m2",
                    });
                    break;
                case "SC07":
                    //VIGAS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC07",
                        Subcategory = "VIGAS",
                        Description = "ENCOFRADO Y DESENCOFRADO NORMAL EN VIGAS",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC07",
                        Subcategory = "VIGAS",
                        Description = "ACERO fy = 4200 kg / cm2 GRADO 60 en VIGAS",
                        Unity = "kg",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC07",
                        Subcategory = "VIGAS",
                        Description = "CONCRETO EN VIGAS f'c=210 kg/cm2",
                        Unity = "m3",
                    });
                    break;
                case "SC08":
                    //LOSAS ALIGERADAS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC08",
                        Subcategory = "LOSAS ALIGERADAS",
                        Description = "CONCRETO EN LOSAS ALIGERADAS f'c=210 kg/cm2",
                        Unity = "m3",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC08",
                        Subcategory = "LOSAS ALIGERADAS",
                        Description = "ACERO fy = 4200 kg / cm2 GRADO 60 en LOSAS ALIGERADAS",
                        Unity = "kg",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC08",
                        Subcategory = "LOSAS ALIGERADAS",
                        Description = "LADRILLO HUECO DE ARCILLA h = 15 cm PARA TECHO ALIGERADO",
                        Unity = "pza",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC08",
                        Subcategory = "LOSAS ALIGERADAS",
                        Description = "ENCOFRADO Y DESENCOFRADO NORMAL EN LOSAS ALIGERADAS",
                        Unity = "m2",
                    });
                    break;
                case "SC09":
                    //COLUMNA DE ARRIOSTRE ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC09",
                        Subcategory = "COLUMNA DE ARRIOSTRE",
                        Description = "ACERO fy = 4200 kg / cm2 GRADO 60 en COLUMNAS",
                        Unity = "kg",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC09",
                        Subcategory = "COLUMNA DE ARRIOSTRE",
                        Description = "ENCOFRADO Y DESENCOFRADO NORMAL EN COLUMNAS",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC09",
                        Subcategory = "COLUMNA DE ARRIOSTRE",
                        Description = "CONCRETO EN COLUMNAS f'c=210 kg/cm2",
                        Unity = "m3",
                    });
                    break;
                case "SC10":
                    //VIGA DE ARRIOSTRE ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC10",
                        Subcategory = "VIGA DE ARRIOSTRE",
                        Description = "CONCRETO VIGAS f'c=175 kg/cm2",
                        Unity = "m3",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC10",
                        Subcategory = "VIGA DE ARRIOSTRE",
                        Description = "ENCOFRADO VIGAS DE ARRIOSTRE",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA07",
                        Category = "CONCRETO ARMADO",
                        SubcategoryCode = "SC10",
                        Subcategory = "VIGA DE ARRIOSTRE",
                        Description = "ACERO CORRUGADO FY = 4200 kg / cm2 GRADO 60",
                        Unity = "kg",
                    });
                    break;
                case "SC11":
                    //MUROS Y TABIQUES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC11",
                        Subcategory = "MUROS Y TABIQUES",
                        Description = "MURO LADRILLO K.K DE ARCILLA 18H(09x013x0.24) AMARRE DE CABEZA,JUNTA 1.5 cm.MORTERO 1:1:5",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC11",
                        Subcategory = "MUROS Y TABIQUES",
                        Description = "TABIQUE DE SUPERBOARD PRO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC11",
                        Subcategory = "MUROS Y TABIQUES",
                        Description = "MURO LADRILLO K.K.DE ARCILLA 18 H(0.09x0.13x0.24) AMARRE DE SOGA JUNTA 1.5 cm.MORTERO 1:1:5",
                        Unity = "m2",
                    });
                    break;
                case "SC12":
                    //REVOQUES ENLUCIDOS Y MOLDURAS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC12",
                        Subcategory = "REVOQUES ENLUCIDOS Y MOLDURAS",
                        Description = "TARRAJEO PRIMARIO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC12",
                        Subcategory = "REVOQUES ENLUCIDOS Y MOLDURAS",
                        Description = "TARRAJEO DE MUROS INTERIORES",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC12",
                        Subcategory = "REVOQUES ENLUCIDOS Y MOLDURAS",
                        Description = "TARRAJEO DE MUROS EXTERIORES",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC12",
                        Subcategory = "REVOQUES ENLUCIDOS Y MOLDURAS",
                        Description = "TARRAJEO DE COLUMNAS",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC12",
                        Subcategory = "REVOQUES ENLUCIDOS Y MOLDURAS",
                        Description = "DERRAMES A = 0.15 m.MORTERO 1:3",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC12",
                        Subcategory = "REVOQUES ENLUCIDOS Y MOLDURAS",
                        Description = "TARRAJEO DE VIGAS",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC12",
                        Subcategory = "REVOQUES ENLUCIDOS Y MOLDURAS",
                        Description = "TARRAJEO DE FONDO DE ESCALERA",
                        Unity = "m2",
                    });
                    break;
                case "SC13":
                    // PISOS Y PAVIMENTOS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC13",
                        Subcategory = "PISOS Y PAVIMENTOS",
                        Description = "CONTRAPISO DE 2''",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC13",
                        Subcategory = "PISOS Y PAVIMENTOS",
                        Description = "CONTRAPISO DE 2'' CON IMPERMEABILIZANTE",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC13",
                        Subcategory = "PISOS Y PAVIMENTOS",
                        Description = "PISO VINILICO FLEXIBLE EN ROLLO E = 2mm INCL. SELLADO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC13",
                        Subcategory = "PISOS Y PAVIMENTOS",
                        Description = "PISO DE ADOQUIN",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC13",
                        Subcategory = "PISOS Y PAVIMENTOS",
                        Description = "PISO DELOSETA DE TERRAZO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC13",
                        Subcategory = "PISOS Y PAVIMENTOS",
                        Description = "PISO DE CEMENTO PULIDO ACABADO BRUÑADO A 0.05 m.ACABADO IMPERMEABILIZADO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC13",
                        Subcategory = "PISOS Y PAVIMENTOS",
                        Description = "COBERTURA DE LADRILLO PASTELERO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC13",
                        Subcategory = "PISOS Y PAVIMENTOS",
                        Description = "PISO GRASS",
                        Unity = "m2",
                    });
                    break;
                case "SC14":
                    // CONTRAZOCALOS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC14",
                        Subcategory = "CONTRAZOCALOS",
                        Description = "CONTRAZOCALO SANITARIO VINILICO FLEXIBLE EN ROLLO CON COVE FORM",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC14",
                        Subcategory = "CONTRAZOCALOS",
                        Description = "CONTRAZOCALO DE TERRAZO",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC14",
                        Subcategory = "CONTRAZOCALOS",
                        Description = "CONTRAZOCALO DE ALUMINIO",
                        Unity = "m",
                    });
                    break;
                case "SC15":
                    // ZOCALOS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC15",
                        Subcategory = "ZOCALOS",
                        Description = "ZOCALO DE CERAMICA 30x30 SERIE GRANILLA COLOR BLANCO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC15",
                        Subcategory = "ZOCALOS",
                        Description = "LAMINADO VINILICO",
                        Unity = "m2",
                    });
                    break;
                case "SC16":
                    // REVESTIMIENTOS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC16",
                        Subcategory = "REVESTIMIENTOS",
                        Description = "FORJADO DE PASOS Y CONTRAPASOS",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC16",
                        Subcategory = "REVESTIMIENTOS",
                        Description = "FORJADO DE DESCANSO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC16",
                        Subcategory = "REVESTIMIENTOS",
                        Description = "REVESTIMIENTO DE PASOS Y CONTRAPASOS CON TERRAZO OSCURO PULIDO",
                        Unity = "m",
                    });
                    break;
                case "SC17":
                    // CIELO RASOS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC17",
                        Subcategory = "CIELO RASOS",
                        Description = "LIMPIEZA DE FONDO DE LOSA",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC17",
                        Subcategory = "CIELO RASOS",
                        Description = "BALDOSAS DE FIBRA MINERAL BIOSOLUBLE 0.61X0.61, BORDE RECTO, TIPO DE SUSPENSIÓN SISMORRESISTENTE",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC17",
                        Subcategory = "CIELO RASOS",
                        Description = "BALDOSAS DE FIBRA MINERAL BIOSOLUBLE CON TRATAMIENTO SANITAS 0.61X0.61, BORDE RECTO, TIPO DE SUSPENSIÓN SISMORRESISTENTE",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC17",
                        Subcategory = "CIELO RASOS",
                        Description = "FALSO CIELO PLANCHA YESO DE 12MM",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC17",
                        Subcategory = "CIELO RASOS",
                        Description = "FALSO CIELO PLANCHA YESO Y SULFATO DE BARIO E = 12.5mm",
                        Unity = "m2",
                    });
                    break;
                case "SC18":
                    // CUBIERTAS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC18",
                        Subcategory = "CUBIERTAS",
                        Description = "COBERTURA DE ESTRUCTURA LIVIANA",
                        Unity = "m2",
                    });
                    break;
                case "SC19":
                    // CARPINTERIA DE MADERA ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC19",
                        Subcategory = "CARPINTERIA DE MADERA",
                        Description = "DIVISIONES DE ALUMINIO CON TABLERO MELAMINE PARA BAÑOS",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC19",
                        Subcategory = "CARPINTERIA DE MADERA",
                        Description = "PUERTA DE MADERA, DE HOJA SIMPLE, CONTRAPLACADA CON TRIPLAY Y MELAMINE, CON SOBRE LUZ INCLUIDO MARCO DE CEDRO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC19",
                        Subcategory = "CARPINTERIA DE MADERA",
                        Description = "PUERTA DE MADERA, DE HOJA DOBLE, CONTRAPLACADA CON TRIPLAY Y MELAMINE, CON SOBRE LUZ INCLUIDO MARCO DE CEDRO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC19",
                        Subcategory = "CARPINTERIA DE MADERA",
                        Description = "PUERTA DE RAYOS X, REVESTIMIENTO PLOMO 2 HOJAS",
                        Unity = "und",
                    });
                    break;
                case "SC20":
                    // CARPINTERIA METALICA ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC20",
                        Subcategory = "CARPINTERIA METALICA",
                        Description = "PUERTA DE EVACUACIÓN RF-90 CON BARRA ANTIPÁNICO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC20",
                        Subcategory = "CARPINTERIA METALICA",
                        Description = "PUERTA METALICA INTERIOR SEGÚN DISEÑO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC20",
                        Subcategory = "CARPINTERIA METALICA",
                        Description = "ESCALERA METALICA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC20",
                        Subcategory = "CARPINTERIA METALICA",
                        Description = "BARANDA DE FIERRO EN ESCALERA",
                        Unity = "m",
                    });
                    break;
                case "SC21":
                    // VIDRIOS, CRISTALES Y SIMILARES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC21",
                        Subcategory = "VIDRIOS, CRISTALES Y SIMILARES",
                        Description = "VENTANA DE ALUMINIO CON VIDRIO LAMINADO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC21",
                        Subcategory = "VIDRIOS, CRISTALES Y SIMILARES",
                        Description = "MURO CORTINA DE CRISTAL TEMPLADO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC21",
                        Subcategory = "VIDRIOS, CRISTALES Y SIMILARES",
                        Description = "ESPEJO CON BISEL",
                        Unity = "m2",
                    });
                    break;
                case "SC22":
                    // CERRAJERIA ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC22",
                        Subcategory = "CERRAJERIA",
                        Description = "BISAGRA ZINCADA 3½'' X 3½''",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC22",
                        Subcategory = "CERRAJERIA",
                        Description = "CERRADURA PARA PUERTA INTERIORES",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC22",
                        Subcategory = "CERRAJERIA",
                        Description = "CERRADURA ANTIPANICO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC22",
                        Subcategory = "CERRAJERIA",
                        Description = "CERRADURA PARA PUERTA DE SS HH DISCAPACITADOS",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC22",
                        Subcategory = "CERRAJERIA",
                        Description = "CERRADURA PARA PUERTA PRINCIPAL",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC22",
                        Subcategory = "CERRAJERIA",
                        Description = "MAESTRANZA DE LLAVES",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC22",
                        Subcategory = "CERRAJERIA",
                        Description = "TOPES EN PISO PARA PUERTA",
                        Unity = "und",
                    });
                    break;
                case "SC23":
                    // MUEBLES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC23",
                        Subcategory = "MUEBLES",
                        Description = "MOBILIARIO MO-38",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC23",
                        Subcategory = "MUEBLES",
                        Description = "MOBILIARIO MO-03",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC23",
                        Subcategory = "MUEBLES",
                        Description = "MOBILIARIO MO-06",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC23",
                        Subcategory = "MUEBLES",
                        Description = "MOBILIARIO MO-42",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC23",
                        Subcategory = "MUEBLES",
                        Description = "MOBILIARIO MO-43",
                        Unity = "und",
                    });
                    break;
                case "SC24":
                    // PINTURA ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC24",
                        Subcategory = "PINTURA",
                        Description = "PINTURA LATEX EN CIELO RASO",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC24",
                        Subcategory = "PINTURA",
                        Description = "PINTURA LATEX EN MUROS INTERIORES",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC24",
                        Subcategory = "PINTURA",
                        Description = "PINTURA LATEX EN MUROS EXTERIORES",
                        Unity = "m2",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC24",
                        Subcategory = "PINTURA",
                        Description = "PINTURA EN TUBERIAS DE INSTALACIONES",
                        Unity = "glb",
                    });
                    break;
                case "SC25":
                    // APARATOS Y ACCESORIOS SANITARIOS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC25",
                        Subcategory = "APARATOS Y ACCESORIOS SANITARIOS",
                        Description = "INODORO ONE PIECE BLANCO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC25",
                        Subcategory = "APARATOS Y ACCESORIOS SANITARIOS",
                        Description = "LAVATORIO PEDESTAL BLANCO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC25",
                        Subcategory = "APARATOS Y ACCESORIOS SANITARIOS",
                        Description = "DUCHA CROMADA DE CABEZA GIRATORIA Y LLAVE MEZCLADORA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC25",
                        Subcategory = "APARATOS Y ACCESORIOS SANITARIOS",
                        Description = "DISPENSADOR DE PAPEL HIGUIENICO CROMADO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC25",
                        Subcategory = "APARATOS Y ACCESORIOS SANITARIOS",
                        Description = "TOALLERO DE LOSA BLANCO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC25",
                        Subcategory = "APARATOS Y ACCESORIOS SANITARIOS",
                        Description = "JABONERA LOSA BLANCO",
                        Unity = "und",
                    });
                    break;
                case "SC26":
                    // SEÑALIZACION ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC26",
                        Subcategory = "SEÑALIZACION",
                        Description = "SI 01 - 60SEÑAL INDICATIVAS",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC26",
                        Subcategory = "SEÑALIZACION",
                        Description = "SEÑALES - ´PINTURA DE TRÁFICO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC26",
                        Subcategory = "SEÑALIZACION",
                        Description = "SI 01 - 60SEÑAL IDENTIFICATIVAS",
                        Unity = "und",
                    });
                    break;
                case "SC27":
                    // VARIOS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC27",
                        Subcategory = "VARIOS",
                        Description = "ASCENSOR(suministro - colocación)",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC27",
                        Subcategory = "VARIOS",
                        Description = "CABECERO MURAL INDIVIDUAL PGD1500",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA08",
                        Category = "ARQUITECTURA",
                        SubcategoryCode = "SC27",
                        Subcategory = "VARIOS",
                        Description = "ASCENSOR CAMILLERO(suministro -colocación)",
                        Unity = "und",
                    });
                    break;
                case "SC28":
                    // CAPACITACIONES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA09",
                        Category = "CAPACITACIONES",
                        SubcategoryCode = "SC28",
                        Subcategory = "CAPACITACIONES",
                        Description = "PLAN DE MITIGACIÓN DE IMPACTO AMBIENTAL",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA09",
                        Category = "CAPACITACIONES",
                        SubcategoryCode = "SC28",
                        Subcategory = "CAPACITACIONES",
                        Description = "ELABORACIÓN DE PLN DE CAPACITACIÓN",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA09",
                        Category = "CAPACITACIONES",
                        SubcategoryCode = "SC28",
                        Subcategory = "CAPACITACIONES",
                        Description = "CAPACITACIÓN DEL RECURSO HUMANO",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA09",
                        Category = "CAPACITACIONES",
                        SubcategoryCode = "SC28",
                        Subcategory = "CAPACITACIONES",
                        Description = "PROMOCIÓN DE LOS SERVICIOS(SENSIBILIZACIÓN Y DIFUSIÓN)",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA09",
                        Category = "CAPACITACIONES",
                        SubcategoryCode = "SC28",
                        Subcategory = "CAPACITACIONES",
                        Description = "PLAN DE MANTENIEMIENTO DE LA INFRAESTRUCTURA Y EQUIPAMIENTO",
                        Unity = "glb",
                    });
                    break;
                case "SC29":
                    // COMUNICACIONES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA10",
                        Category = "INSTALACIONES ESPECIALES",
                        SubcategoryCode = "SC29",
                        Subcategory = "COMUNICACIONES",
                        Description = "SUMINISTRO, INSTALACIÓN Y PUESTA EN MARCHA DEL SISTEMA DE COMUNICACIONES",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA10",
                        Category = "INSTALACIONES ESPECIALES",
                        SubcategoryCode = "SC29",
                        Subcategory = "COMUNICACIONES",
                        Description = "SUMINISTRO, INSTALACIÓN SISTEMA DE TELEFONÍA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA10",
                        Category = "INSTALACIONES ESPECIALES",
                        SubcategoryCode = "SC29",
                        Subcategory = "COMUNICACIONES",
                        Description = "SUMINISTRO, INSTALACIÓN SISTEMA DE LLAMADO DE ENFERMERA",
                        Unity = "und",
                    });
                    break;
                case "SC30":
                    // SISTEMA CCTV ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA10",
                        Category = "INSTALACIONES ESPECIALES",
                        SubcategoryCode = "SC30",
                        Subcategory = "SISTEMA CCTV",
                        Description = "SUMINISTRO, INSTALACIÓN Y PUETA EN MARCHA DEL SISTEMA DE CCTV",
                        Unity = "und",
                    });                    
                    break;
                case "SC31":
                    // DETECCIÓN Y ALARMAS CONTRAINCENDIO ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA10",
                        Category = "INSTALACIONES ESPECIALES",
                        SubcategoryCode = "SC31",
                        Subcategory = "DETECCIÓN Y ALARMAS CONTRAINCENDIO",
                        Description = "SUMINISTRO, INSTALACIÓN Y PUESTA EN MARCHA DEL SISTEMA DE CONTRAINCENDIO",
                        Unity = "und",
                    });                    
                    break;
                case "SC32":
                    // SISTEMA AUDIO Y VIDEO ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA10",
                        Category = "INSTALACIONES ESPECIALES",
                        SubcategoryCode = "SC32",
                        Subcategory = "SISTEMA AUDIO Y VIDEO",
                        Description = "SUMINISTRO, INSTALACIÓN Y PUESTA EN MARCHA DEL SISTEMA DE DE SONIDO AMBIENTAL Y PERIFONEO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA10",
                        Category = "INSTALACIONES ESPECIALES",
                        SubcategoryCode = "SC32",
                        Subcategory = "SISTEMA AUDIO Y VIDEO",
                        Description = "SUMINISTRO, INSTALACIÓN Y PUESTA EN MARCHA DEL SISTEMA DE TV-CATV",
                        Unity = "und",
                    });
                    break;
                case "SC33":
                    // EQUIPAMIENTO ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "ELECTROCARDIOGRAFO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "ECÓGRAFO PORTATIL",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "BOMBA DE INFUSIÓN DE 1 CANAL",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "COCHE DE PARO EQUIPADO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "INCUBADORA DE TRANSPORTE",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "MONITOR FETAL",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "PULSIOXIMETRO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "MONITOR DE FUNCIONES VITALES",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "EQUIPOS DE RAYOS X ESTACIONARIO DIGITAL",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "NEBULIZADOR",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "MALETIN DE REANIMACIÓN NEONATAL",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "MALETIN DE REANIMACIÓN ADULTO PEDIATRICO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "EQUIPO DE RAYOS X DENTAL RODABLE DIGITAL",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "ESTERILIZADOR CON GENERADOR ELÉCTRICO DE VAPOR DE 50 LITROS MÍNIMO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "CONTADOR DE CÉLULAS",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "ANALIZADOR BIOQUIMICO SEMI AUTOMATICO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "BAÑO MARIA DE 20 A 25 LITROS",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "GLUCÓMETRO PORTÁTIL",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "CENTRÍFUGA UNIVERSAL PARA 24 TUBOS",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "CENTRÍFUGA PARA MICROHEMATOCRITO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "HEMOGLOBINÓMETRO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "ESTERILIZADOR POR CALOR SECO 50 LITROS",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "MALETIN DE REANIMACIÓN-ADULTO PEDIATRICO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "CINTA METRICA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "LÁMPARA QUIRURGICA DE TECHO SIMPLE",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "PULSIOMETRO PORTATIL",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "LAMPARA QUIRURGICA RODABLE",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "CUNA DE CALOR RADIANTE",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "ESTERILIZADOR CON GENERADOR ELECTRICO DE VAPOR VERTICAL DE 30 LITROS",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "INCUBADORA PARA CULTIVO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "UNIDAD DENTAL COMPLETA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "DESFIBRILADOR CON MONITOR Y PALETAS EXTERNAS",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "MICROSCOPIO BINOCULAR ESTANDAR",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "ASPIRADOR DE SECRECIONES RODABLE",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "DETECTOR DE LATIDOS FETALES PORTATIL",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "ECÓGRAFO DOPPLER COLOR 3D",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "CAMA CAMILLA MULTIPROPOSITO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA11",
                        Category = "EQUIPAMIENTO",
                        SubcategoryCode = "SC33",
                        Subcategory = "EQUIPAMIENTO",
                        Description = "MESA DE PARTOS",
                        Unity = "und",
                    });
                    break;
                case "SC34":
                    // SUMINISTRO DE ENERGÍA 380/220v CON NEUTRO CORRIDO Y 60 HZ ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA12",
                        Category = "SUMINISTRO DE ENERGÍA 380/220v CON NEUTRO CORRIDO Y 60 HZ",
                        SubcategoryCode = "SC34",
                        Subcategory = "SUMINISTRO DE ENERGÍA 380/220v CON NEUTRO CORRIDO Y 60 HZ",
                        Description = "ALIM 3x95 + N / 1x70 + T / 1x35mm2 N2XOH(ACOMETIDA)",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA12",
                        Category = "SUMINISTRO DE ENERGÍA 380/220v CON NEUTRO CORRIDO Y 60 HZ",
                        SubcategoryCode = "SC34",
                        Subcategory = "SUMINISTRO DE ENERGÍA 380/220v CON NEUTRO CORRIDO Y 60 HZ",
                        Description = "TUBERIA PVC - P 100mm2",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA12",
                        Category = "SUMINISTRO DE ENERGÍA 380/220v CON NEUTRO CORRIDO Y 60 HZ",
                        SubcategoryCode = "SC34",
                        Subcategory = "SUMINISTRO DE ENERGÍA 380/220v CON NEUTRO CORRIDO Y 60 HZ",
                        Description = "EXCAVACION, TIERRA CERNIDA, MATERIAL AFIRMADO, SEÑALIZACIÓN Y COMPACTACIÓN DE ZANJA 0.6x0.65",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA12",
                        Category = "SUMINISTRO DE ENERGÍA 380/220v CON NEUTRO CORRIDO Y 60 HZ",
                        SubcategoryCode = "SC34",
                        Subcategory = "SUMINISTRO DE ENERGÍA 380/220v CON NEUTRO CORRIDO Y 60 HZ",
                        Description = "BUZON DE 0.60x0.7x0.8m",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA12",
                        Category = "SUMINISTRO DE ENERGÍA 380/220v CON NEUTRO CORRIDO Y 60 HZ",
                        SubcategoryCode = "SC34",
                        Subcategory = "SUMINISTRO DE ENERGÍA 380/220v CON NEUTRO CORRIDO Y 60 HZ",
                        Description = "MURETE PARA SUMINISTRO ELECTRICO",
                        Unity = "und",
                    });
                    break;
                case "SC35":
                    // TABLEROS ELECTRICOS GENERALES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA13",
                        Category = "TABLEROS ELECTRICOS GENERALES",
                        SubcategoryCode = "SC35",
                        Subcategory = "TABLEROS ELECTRICOS GENERALES",
                        Description = "TABLERO TD-GE",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA13",
                        Category = "TABLEROS ELECTRICOS GENERALES",
                        SubcategoryCode = "SC35",
                        Subcategory = "TABLEROS ELECTRICOS GENERALES",
                        Description = "TABLERO TG",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA13",
                        Category = "TABLEROS ELECTRICOS GENERALES",
                        SubcategoryCode = "SC35",
                        Subcategory = "TABLEROS ELECTRICOS GENERALES",
                        Description = "TABLERO TD-AA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA13",
                        Category = "TABLEROS ELECTRICOS GENERALES",
                        SubcategoryCode = "SC35",
                        Subcategory = "TABLEROS ELECTRICOS GENERALES",
                        Description = "TABLERO TD-ASC",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA13",
                        Category = "TABLEROS ELECTRICOS GENERALES",
                        SubcategoryCode = "SC35",
                        Subcategory = "TABLEROS ELECTRICOS GENERALES",
                        Description = "TABLERO T-GE",
                        Unity = "und",
                    });
                    break;
                case "SC36":
                    // TABLEROS ELECTRICOS DISTRIBUCIÓN ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO TD-1 - 01",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO TD-1 - 02",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO TD-2 - 01",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO TD-2 - 02",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO TD-2 - 03",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO STD-2 - 04",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO TD-3 - 01",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO TD-3 - 02",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO TD-3 - 03",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO TD-3 - 04",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO TD-4 - 01",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC36",
                        Subcategory = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        Description = "TABLERO TD-5 - 01",
                        Unity = "und",
                    });
                    break;
                case "SC37":
                    // TABLEROS EQUIPOS, SEGURIDAD Y OTROS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-BA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-BCI",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-EC",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-RX",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-UC - 01",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-UC - 02",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-UC - 03",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-UPS",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-EST",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-ASC1",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-ASC2",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA14",
                        Category = "TABLEROS ELECTRICOS DISTRIBUCIÓN",
                        SubcategoryCode = "SC37",
                        Subcategory = "TABLEROS EQUIPOS, SEGURIDAD Y OTROS",
                        Description = "TABLERO T-BEX",
                        Unity = "und",
                    });
                    break;
                case "SC38":
                    // EQUIPOS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA15",
                        Category = "EQUIPOS",
                        SubcategoryCode = "SC38",
                        Subcategory = "EQUIPOS",
                        Description = "TRANSFORMADOR Y BY PASS",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA15",
                        Category = "EQUIPOS",
                        SubcategoryCode = "SC38",
                        Subcategory = "EQUIPOS",
                        Description = "UPS(8KW, 10KVA, 60HZ)",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA15",
                        Category = "EQUIPOS",
                        SubcategoryCode = "SC38",
                        Subcategory = "EQUIPOS",
                        Description = "GRUPO ELECTRÓGENO DE 200KW,250KVA, 380 / 220V, 60HZ",
                        Unity = "und",
                    });
                    break;
                case "SC39":
                    // ALIMENTADORES ELECTRICOS PRINCIPALES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "C - GE1: 3x25 + N / 1x16 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CBI - 1: 3x70 + N / 1x35 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 1: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 2: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 3: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 4: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 5: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 6: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 7: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 8: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 9: 3x25 + N / 1x16 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 10: 3x70 + N / 1x35 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 11: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 12: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CN - 12: 3x6 + N / 1x6 + T / 1x4mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CE - 1: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CE - 2: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CE - 3: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CE - 4: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CE - 5: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CE - 6: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CE - 7: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CE - 8: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CE - 9: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CE - 10: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC39",
                        Subcategory = "ALIMENTADORES ELECTRICOS PRINCIPALES",
                        Description = "CE - 11: 3x10 + N / 1x10 + T / 1x10mm2 N2XOH",
                        Unity = "m",
                    });
                    break;
                case "SC40":
                    // ALIMENTADORES ELECTRICOS SECUNDARIOS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC40",
                        Subcategory = "ALIMENTADORES ELECTRICOS SECUNDARIOS",
                        Description = "C24 - 5: 1x10 + N / 1x10 + T / 1x10mm2 LSOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC40",
                        Subcategory = "ALIMENTADORES ELECTRICOS SECUNDARIOS",
                        Description = "CAA - 1: 3x10 + N / 1x10 + T / 1x10mm2 LSOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC40",
                        Subcategory = "ALIMENTADORES ELECTRICOS SECUNDARIOS",
                        Description = "CAA - 2: 3x10 + N / 1x10 + T / 1x10mm2 LSOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC40",
                        Subcategory = "ALIMENTADORES ELECTRICOS SECUNDARIOS",
                        Description = "CAA - 3: 3x10 + N / 1x10 + T / 1x10mm2 LSOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC40",
                        Subcategory = "ALIMENTADORES ELECTRICOS SECUNDARIOS",
                        Description = "CA - 1: 3x10 + N / 1x10 + T / 1x10mm2 LSOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC40",
                        Subcategory = "ALIMENTADORES ELECTRICOS SECUNDARIOS",
                        Description = "CA - 2: 3x16 + N / 1x16 + T / 1x10mm2 LSOH",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA16",
                        Category = "ALIMENTADORES ELECTRICOS",
                        SubcategoryCode = "SC40",
                        Subcategory = "ALIMENTADORES ELECTRICOS SECUNDARIOS",
                        Description = "C25 - 4: 1x6 + N / 1x2.5 + T / 1x2.5mm2 LSOH",
                        Unity = "m",
                    });
                    break;
                case "SC41":
                    // TUBERIA Y CAJAS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC41",
                        Subcategory = "TUBERIA Y CAJAS",
                        Description = "TUBERIA 50mmØ PVC-P",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC41",
                        Subcategory = "TUBERIA Y CAJAS",
                        Description = "CAJA CUADRADA 100X100X75MM",
                        Unity = "und",
                    });
                    break;
                case "SC42":
                    // SALIDAS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC42",
                        Subcategory = "SALIDAS",
                        Description = "SALIDA DE ALUMBRADO EN TECHO(CAJA OCT. 100x40mm, C / TUB.20 mmØ  PVC - P.Y CABLE LSOH 1x2.5 + N / 1.2.5mm2)",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC42",
                        Subcategory = "SALIDAS",
                        Description = "SALIDA DE ALUMBRADO EN PARED(CAJA OCT. 100X40mm, CABLE  LSOH 1x2.5 + N / 1.2.5mm2)",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC42",
                        Subcategory = "SALIDAS",
                        Description = "SALIDA DE ALUMBRADO PARA ARTEFACTO DE EMERGENCIA(CAJA OCT. 100x55mm, C / TUB.DE 20 mmØ PVC - P Y CABLE LSOH 2 - 1x4 + 1x4 mm2)",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC42",
                        Subcategory = "SALIDAS",
                        Description = "SALIDA DE ALUMBRADO PARA SEÑALETICA(CAJA OCT. 100x55mm, C / TUB.DE 20 mmØ PVC - P Y CABLE  LSOH 1x2.5 + N / 1.2.5mm2)",
                        Unity = "pto",
                    });
                    break;
                case "SC43":
                    // INTERRUPTORES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC43",
                        Subcategory = "INTERRUPTORES",
                        Description = "INTERRUPTOR UNIPOLAR SIMPLE(CAJA RECT.100x55x50mm, CABLE LSOH 2.5mm2, TUB 20 PVC - P)",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC43",
                        Subcategory = "INTERRUPTORES",
                        Description = "INTERRUPTOR UNIPOLAR DOBLE(CAJA RECT.100x55x50mm, CABLE LSOH 2.5mm2, TUB 20 PVC - P)",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC43",
                        Subcategory = "INTERRUPTORES",
                        Description = "INTERRUPTOR DE 2 VIAS(CAJA RECT.100x55x50mm, CABLE LSOH 25mm2, TUB. 20 mm PVC - P)",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC43",
                        Subcategory = "INTERRUPTORES",
                        Description = "INTERRUPTOR DE 3 VIAS(CAJA RECT.100x55x50mm, CABLE LSOH 25mm2, TUB. 20 mm PVC - P)",
                        Unity = "und",
                    });
                    break;
                case "SC44":
                    // TOMACORRIENTES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC44",
                        Subcategory = "TOMACORRIENTES",
                        Description = "SALIDA PARA TOMACORRIENTE DOBLE 2P + T DE GRADO HOSPITALARIO 16A - 220V(INCLUYE TUBERIA 20mm ? PVC - P, CAJA 130X71X52mm F°G°, CABLE LS0H",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC44",
                        Subcategory = "TOMACORRIENTES",
                        Description = "SALIDA PARA TOMACORRIENTE A PRUEBA DE AGUA(INCLUYE TUBERIA 20mm ? PVC - P, CAJA 100X55X50mm F°G°, CABLE LS0H 1x2.5 + N / 1x4 + T1x4mm2, 130X71X52mm F°G°, CABLE LS0H",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC44",
                        Subcategory = "TOMACORRIENTES",
                        Description = "SALIDA PARA TOMACORRIENTE DOBLE 2P + T DE GRADO HOSPITALARIO 16A - 220V EMPOTRADO EN PISO(INCLUYE TUBERIA 20mm ? PVC - P, CAJA 130X71X52mm F°G°, CABLE LS0H 1x2.5 + N / 1x4 + T1x4mm2, USO MEDICO O SEGURIDAD DE VIDA).",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC44",
                        Subcategory = "TOMACORRIENTES",
                        Description = "SALIDA PARA TOMACORRIENTE SIMPLE 2P + T DE GRADO HOSPITALARIO 10A - 220V EMPOTRADO EN PISO(INCLUYE TUBERIA 20mm ? PVC - P, CAJA 130X71X52mm F°G°, CABLE LS0H 1x2.5 + N / 1x4 + T1x4mm2, USO MEDICO O SEGURIDAD DE VIDA).",
                        Unity = "pto",
                    });
                    break;
                case "SC45":
                    // SALIDAS DE FUERZA ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC45",
                        Subcategory = "SALIDAS DE FUERZA",
                        Description = "SALIDA DE FUERZA EN PISO PARA BEX(INCLUYE TUBERIA 20mm ? PVC - P, CAJA 100x100x50mm F°G°, CABLE LS0H, H = 0.35m.SALVO QUE INDIQUE LO CONTRARIO)",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC45",
                        Subcategory = "SALIDAS DE FUERZA",
                        Description = "SALIDA DE FUERZA EN FCR PARA URV(INCLUYE TUBERIA 20mm ? PVC - P, CAJA 100x100x50mm F°G°, CABLE LS0H, H = 0.35m.SALVO QUE INDIQUE LO CONTRARIO)",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC45",
                        Subcategory = "SALIDAS DE FUERZA",
                        Description = "SALIDA DE FUERZA EN PISO PARA UC1(INCLUYE TUBERIA 50mm ? PVC - P, CAJA 100x100x50mm F°G°, CABLE N2XOH 3X10 + N / 1X10 + T / 1X10MM2, H = 0.35m.SALVO QUE INDIQUE LO CONTRARIO)",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC45",
                        Subcategory = "SALIDAS DE FUERZA",
                        Description = "SALIDA DE FUERZA EN PISO PARA UC2(INCLUYE TUBERIA 20mm ? PVC - P, CAJA 100x100x50mm F°G°, CABLE LS0H 1X4 + N / 1X4 + T / 1X4MM2, H = 0.35m.SALVO QUE INDIQUE LO CONTRARIO",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA17",
                        Category = "TUBERIA Y CAJAS",
                        SubcategoryCode = "SC45",
                        Subcategory = "SALIDAS DE FUERZA",
                        Description = "SALIDA DE FUERZA EN PISO PARA UC1(INCLUYE TUBERIA 50mm ? PVC - P, CAJA 100x100x50mm F°G°, CABLE N2XOH 3X10 + N / 1X10 + T / 1X10MM2, H = 0.35m.SALVO QUE INDIQUE LO CONTRARIO)",
                        Unity = "pto",
                    });
                    break;
                case "SC46":
                    // ARTEFACTOS DE ILUMINACION ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA18",
                        Category = "ARTEFACTOS DE ILUMINACION",
                        SubcategoryCode = "SC46",
                        Subcategory = "ARTEFACTOS DE ILUMINACION",
                        Description = "ARTEFACTO DE ALUMBRADO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA18",
                        Category = "ARTEFACTOS DE ILUMINACION",
                        SubcategoryCode = "SC46",
                        Subcategory = "ARTEFACTOS DE ILUMINACION",
                        Description = "ARTEFACTO SPOT LIGHT",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA18",
                        Category = "ARTEFACTOS DE ILUMINACION",
                        SubcategoryCode = "SC46",
                        Subcategory = "ARTEFACTOS DE ILUMINACION",
                        Description = "LUMINARIA PARA EMPOTRAR 2X36W 6000K C/ REJILLAS AL.ANONIZADO / ALTO FACTOR",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA18",
                        Category = "ARTEFACTOS DE ILUMINACION",
                        SubcategoryCode = "SC46",
                        Subcategory = "ARTEFACTOS DE ILUMINACION",
                        Description = "LUMINARIA PARA ADOSAR 2X36W 6000K C/ REJILLAS AL.ANONIZADO / ALTO FACTOR",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA18",
                        Category = "ARTEFACTOS DE ILUMINACION",
                        SubcategoryCode = "SC46",
                        Subcategory = "ARTEFACTOS DE ILUMINACION",
                        Description = "LUMINARIA PARA ADOSAR 2X36W 6000K BALASTO ELECT.C / CUBIERTA GRADO IP65",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA18",
                        Category = "ARTEFACTOS DE ILUMINACION",
                        SubcategoryCode = "SC46",
                        Subcategory = "ARTEFACTOS DE ILUMINACION",
                        Description = "BRAQUETE MOELO PL - C 9W",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA18",
                        Category = "ARTEFACTOS DE ILUMINACION",
                        SubcategoryCode = "SC46",
                        Subcategory = "ARTEFACTOS DE ILUMINACION",
                        Description = "LAMP.SUSP.PARED INDIRECTA 23W",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA18",
                        Category = "ARTEFACTOS DE ILUMINACION",
                        SubcategoryCode = "SC46",
                        Subcategory = "ARTEFACTOS DE ILUMINACION",
                        Description = "LAMP.CIALITICA C/ BATT - CHARGE",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA18",
                        Category = "ARTEFACTOS DE ILUMINACION",
                        SubcategoryCode = "SC46",
                        Subcategory = "ARTEFACTOS DE ILUMINACION",
                        Description = "LUMINARIA DE EMERGENCIA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA18",
                        Category = "ARTEFACTOS DE ILUMINACION",
                        SubcategoryCode = "SC46",
                        Subcategory = "ARTEFACTOS DE ILUMINACION",
                        Description = "SEÑALETICA(SALIDA)",
                        Unity = "und",
                    });
                    break;
                case "SC47":
                    // SISTEMA DE TIERRA ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA18",
                        Category = "ARTEFACTOS DE ILUMINACION",
                        SubcategoryCode = "SC47",
                        Subcategory = "SISTEMA DE TIERRA",
                        Description = "POZO A TIERRA",
                        Unity = "und",
                    });                    
                    break;
                case "SC48":
                    // ILUMINACION EXTERIOR ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA19",
                        Category = "ILUMINACION EXTERIOR",
                        SubcategoryCode = "SC48",
                        Subcategory = "ILUMINACION EXTERIOR",
                        Description = "POSTE CAC 8 / 200 / 120 / 240(INCLUYE CIMENTACIÓN) SEGÚN DETALLE",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA19",
                        Category = "ILUMINACION EXTERIOR",
                        SubcategoryCode = "SC48",
                        Subcategory = "ILUMINACION EXTERIOR",
                        Description = "PASTORAL DE F°G° 1.30X2.50M",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA19",
                        Category = "ILUMINACION EXTERIOR",
                        SubcategoryCode = "SC48",
                        Subcategory = "ILUMINACION EXTERIOR",
                        Description = "LAMPARA DE HALOGENURO MET. 150W",
                        Unity = "und",
                    });
                    break;
                case "SC49":
                    // SISTEMA DE DESAGUE ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC49",
                        Subcategory = "SISTEMA DE DESAGUE",
                        Description = "SALIDA DESAGUE DE PVC SAL 2''",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC49",
                        Subcategory = "SISTEMA DE DESAGUE",
                        Description = "SALIDA DESAGUE DE PVC-SAL 4''",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC49",
                        Subcategory = "SISTEMA DE DESAGUE",
                        Description = "SALIDA VENTILACION DE PVC-SAL 2''",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC49",
                        Subcategory = "SISTEMA DE DESAGUE",
                        Description = "MONTANTE DE TUBERIA PVC SAL 4''",
                        Unity = "m",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC49",
                        Subcategory = "SISTEMA DE DESAGUE",
                        Description = "REGISTRO DE BRONCE  3''",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC49",
                        Subcategory = "SISTEMA DE DESAGUE",
                        Description = "CAJAS DE REGISTRO DE DESAGUE 12'' x 24''",
                        Unity = "und",
                    });
                    break;
                case "SC50":
                    // SISTEMA DE AGUA FRIA ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC50",
                        Subcategory = "SISTEMA DE AGUA FRIA",
                        Description = "SALIDA DE AGUA FRIA TUBERIA PVC C - 10 O 1 / 2''",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC50",
                        Subcategory = "SISTEMA DE AGUA FRIA",
                        Description = "SALIDA DE AGUA FRIA TUBERIA PVC C - 10 O 1 / 2''",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC50",
                        Subcategory = "SISTEMA DE AGUA FRIA",
                        Description = "VALVULA COMPUERTA DE 1 / 2''",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC50",
                        Subcategory = "SISTEMA DE AGUA FRIA",
                        Description = "VALVULA COMPUERTA DE 3 / 4''",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC50",
                        Subcategory = "SISTEMA DE AGUA FRIA",
                        Description = "SISTEMA DE RIEGO CONVENCIONAL",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC50",
                        Subcategory = "SISTEMA DE AGUA FRIA",
                        Description = "TANQUE DE AGUA DE ETERNIT DE 1000 LITROS INCLUYE ACC.INTERNOS",
                        Unity = "und",
                    });
                    break;
                case "SC51":
                    // SISTEMA DE AGUA CALIENTE ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC51",
                        Subcategory = "SISTEMA DE AGUA CALIENTE",
                        Description = "SALIDA AGUA CALIENTE TUBERIA CPVC O 1 / 2''",
                        Unity = "pto",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA20",
                        Category = "INSTALACIONES SANITARIAS",
                        SubcategoryCode = "SC51",
                        Subcategory = "SISTEMA DE AGUA CALIENTE",
                        Description = "VALVULA COMPUERTA DE 1 / 2''",
                        Unity = "und",
                    });
                    break;
                case "SC52":
                    // INSTALACIONES GASES MEDICINALES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA21",
                        Category = "INSTALACIONES GASES MEDICINALES",
                        SubcategoryCode = "SC52",
                        Subcategory = "INSTALACIONES GASES MEDICINALES",
                        Description = "CENTRAL DE OXÍGENO 2x6",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA21",
                        Category = "INSTALACIONES GASES MEDICINALES",
                        SubcategoryCode = "SC52",
                        Subcategory = "INSTALACIONES GASES MEDICINALES",
                        Description = "BOMBA DE VACIO",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA21",
                        Category = "INSTALACIONES GASES MEDICINALES",
                        SubcategoryCode = "SC52",
                        Subcategory = "INSTALACIONES GASES MEDICINALES",
                        Description = "RED DE DISTRIBUCIÓN",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA21",
                        Category = "INSTALACIONES GASES MEDICINALES",
                        SubcategoryCode = "SC52",
                        Subcategory = "INSTALACIONES GASES MEDICINALES",
                        Description = "VALVULA DE BOLA",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA21",
                        Category = "INSTALACIONES GASES MEDICINALES",
                        SubcategoryCode = "SC52",
                        Subcategory = "INSTALACIONES GASES MEDICINALES",
                        Description = "FLEXIBLE JUNTA EXPANSIÓN",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA21",
                        Category = "INSTALACIONES GASES MEDICINALES",
                        SubcategoryCode = "SC52",
                        Subcategory = "INSTALACIONES GASES MEDICINALES",
                        Description = "TOMA DE GASES",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA21",
                        Category = "INSTALACIONES GASES MEDICINALES",
                        SubcategoryCode = "SC52",
                        Subcategory = "INSTALACIONES GASES MEDICINALES",
                        Description = "SELECTOR DE FUENTES",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA21",
                        Category = "INSTALACIONES GASES MEDICINALES",
                        SubcategoryCode = "SC52",
                        Subcategory = "INSTALACIONES GASES MEDICINALES",
                        Description = "COLECTORES",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA21",
                        Category = "INSTALACIONES GASES MEDICINALES",
                        SubcategoryCode = "SC52",
                        Subcategory = "INSTALACIONES GASES MEDICINALES",
                        Description = "CAJA DE CIERRE Y ALARMA",
                        Unity = "glb",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA21",
                        Category = "INSTALACIONES GASES MEDICINALES",
                        SubcategoryCode = "SC52",
                        Subcategory = "INSTALACIONES GASES MEDICINALES",
                        Description = "RED BUS SCAN",
                        Unity = "glb",
                    });
                    break;
                case "SC53":
                    // INSTALACIONES ESPECIALES ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA22",
                        Category = "INSTALACIONES ESPECIALES",
                        SubcategoryCode = "SC53",
                        Subcategory = "INSTALACIONES ESPECIALES",
                        Description = "GABINETES Y RED CONTRAINCENDIO",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA22",
                        Category = "INSTALACIONES ESPECIALES",
                        SubcategoryCode = "SC53",
                        Subcategory = "INSTALACIONES ESPECIALES",
                        Description = "MOTOBOMBA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA22",
                        Category = "INSTALACIONES ESPECIALES",
                        SubcategoryCode = "SC53",
                        Subcategory = "INSTALACIONES ESPECIALES",
                        Description = "BOMBA HIDRONEUMATICA",
                        Unity = "und",
                    });
                    break;
                case "SC54":
                    // INSTALACIONES MECÁNICAS ====================================================================
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA23",
                        Category = "INSTALACIONES MECÁNICAS",
                        SubcategoryCode = "SC54",
                        Subcategory = "INSTALACIONES MECÁNICAS",
                        Description = "REJILLA DIFUSOR Y RETORNO 36 * 36",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA23",
                        Category = "INSTALACIONES MECÁNICAS",
                        SubcategoryCode = "SC54",
                        Subcategory = "INSTALACIONES MECÁNICAS",
                        Description = "DUCTO DE 0.50 * 0.3",
                        Unity = "kg",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA23",
                        Category = "INSTALACIONES MECÁNICAS",
                        SubcategoryCode = "SC54",
                        Subcategory = "INSTALACIONES MECÁNICAS",
                        Description = "UNIDAD EXTRACTORA UE - 01 )SPLIT DUCTO)",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA23",
                        Category = "INSTALACIONES MECÁNICAS",
                        SubcategoryCode = "SC54",
                        Subcategory = "INSTALACIONES MECÁNICAS",
                        Description = "UNIDAD CONDENSADORA UC 02",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA23",
                        Category = "INSTALACIONES MECÁNICAS",
                        SubcategoryCode = "SC54",
                        Subcategory = "INSTALACIONES MECÁNICAS",
                        Description = "UNIDAD CONDENSADORA UC 01 ) VOL REFRIGERANTE VARIABLE",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA23",
                        Category = "INSTALACIONES MECÁNICAS",
                        SubcategoryCode = "SC54",
                        Subcategory = "INSTALACIONES MECÁNICAS",
                        Description = "UNIDAD CDISTRIBUIDORA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA23",
                        Category = "INSTALACIONES MECÁNICAS",
                        SubcategoryCode = "SC54",
                        Subcategory = "INSTALACIONES MECÁNICAS",
                        Description = "UNIDAD CASET DE REFR.VARIABLE",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA23",
                        Category = "INSTALACIONES MECÁNICAS",
                        SubcategoryCode = "SC54",
                        Subcategory = "INSTALACIONES MECÁNICAS",
                        Description = "UNIDAD HVAC DE PRECISIÓN UE 03",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA23",
                        Category = "INSTALACIONES MECÁNICAS",
                        SubcategoryCode = "SC54",
                        Subcategory = "INSTALACIONES MECÁNICAS",
                        Description = "UNIDAD B-EX DE ESCALERA DE EMERGENCIA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA23",
                        Category = "INSTALACIONES MECÁNICAS",
                        SubcategoryCode = "SC54",
                        Subcategory = "INSTALACIONES MECÁNICAS",
                        Description = "UNIDAD B-EX DE ESCALERA DE EMERGENCIA",
                        Unity = "und",
                    });
                    budgetDetails.Add(new BudgetDetail
                    {
                        BudgetId = -1,
                        CategoryCode = "CA23",
                        Category = "INSTALACIONES MECÁNICAS",
                        SubcategoryCode = "SC54",
                        Subcategory = "INSTALACIONES MECÁNICAS",
                        Description = "ACCESORIOS DE INSTALACION",
                        Unity = "glb",
                    });
                    break;
            }
            
            

            return budgetDetails.ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}