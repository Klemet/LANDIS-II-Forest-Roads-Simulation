﻿//  Author: Clément Hardy
// With mant elements shamelessely copied from the corresponding class
// in the "Base Fire" extension by Robert M. Scheller and James B. Domingo

using Landis.Landscapes;
using Landis.Core;
using Landis.SpatialModeling;
using Landis.Library.AgeOnlyCohorts;

namespace Landis.Extension.ForestRoadsSimulation
{
	public static class SiteVars
	{
		// Variable that indicates what road is in this site
		private static SiteVarDistinct<RoadType> roadsInLandscape;
		// Variables relative to different characteristics of sites :
		// elevation, water, etc. = 0 if it wasn't inputed by the user.
		private static SiteVarDistinct<int> coarseElevation;
		private static SiteVarDistinct<int> fineElevation;
		private static SiteVarDistinct<int> coarseWater;
		private static SiteVarDistinct<int> fineWater;
		private static SiteVarDistinct<SoilRegion> soils;
		// The cohorts on the sites.
		private static ISiteVar<ISiteCohorts> cohorts;

		//---------------------------------------------------------------------

		public static void Initialize()
		{
			// CAREFULL : By default, LANDIS-II creates variables where the inactive sites all have the same value !
			// For our variable to work on inactive sites, we have to tell him to create a variable with distinct values
			// for every inactive site
			roadsInLandscape = (SiteVarDistinct<RoadType>)PlugIn.ModelCore.Landscape.NewSiteVar<RoadType>(InactiveSiteMode.DistinctValues);
			coarseElevation = (SiteVarDistinct<int>)PlugIn.ModelCore.Landscape.NewSiteVar<int>(InactiveSiteMode.DistinctValues);
			fineElevation = (SiteVarDistinct<int>)PlugIn.ModelCore.Landscape.NewSiteVar<int>(InactiveSiteMode.DistinctValues);
			coarseWater = (SiteVarDistinct<int>)PlugIn.ModelCore.Landscape.NewSiteVar<int>(InactiveSiteMode.DistinctValues);
			fineWater = (SiteVarDistinct<int>)PlugIn.ModelCore.Landscape.NewSiteVar<int>(InactiveSiteMode.DistinctValues);
			soils = (SiteVarDistinct<SoilRegion>)PlugIn.ModelCore.Landscape.NewSiteVar<SoilRegion>(InactiveSiteMode.DistinctValues);

			cohorts = PlugIn.ModelCore.GetSiteVar<ISiteCohorts>("Succession.AgeCohorts");
		}

		//---------------------------------------------------------------------

		public static SiteVarDistinct<RoadType> RoadsInLandscape
		{
			get
			{
				return roadsInLandscape;
			}
		}

		public static SiteVarDistinct<int> CoarseElevation
		{
			get
			{
				return coarseElevation;
			}
		}

		public static SiteVarDistinct<int> FineElevation
		{
			get
			{
				return fineElevation;
			}
		}

		public static SiteVarDistinct<int> CoarseWater
		{
			get
			{
				return coarseWater;
			}
		}

		public static SiteVarDistinct<int> FineWater
		{
			get
			{
				return fineWater;
			}
		}

		public static SiteVarDistinct<SoilRegion> Soils
		{
			get
			{
				return soils;
			}
		}


		public static ISiteVar<ISiteCohorts> Cohorts
		{
			get
			{
				return cohorts;
			}
		}

	}
}