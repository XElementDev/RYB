using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.Resources.Core;

namespace XElement.RYB.UI.UWP.Localization
{
    [TestClass]
    public class TestLocalization
    {
        [TestMethod]
        public void Localization_DictKeysAreEquivalent_defaultVsDe()
        {
            var defaultContext = ResourceContext.GetForViewIndependentUse();
            var deDeContext = CreateSingleLanguageContext( CULTURE_GERMAN );
            var defaultK2RcMap = GetKeyToResCandidateMap( defaultContext );
            var deDeK2RcMap = GetKeyToResCandidateMap( deDeContext );
            var defaultKeys = GetKeysFrom( defaultK2RcMap, rc => rc != null ).ToList();
            var deDeKeys = GetKeysFrom( deDeK2RcMap, rc => !rc.IsDefault ).ToList();

            CollectionAssert.AreEquivalent( defaultKeys, deDeKeys );
        }


        [TestMethod]
        public void Localization_default_NotEmptyAndNoneNullAndNoneEmpty()
        {
            var defaultContext = ResourceContext.GetForViewIndependentUse();
            var defaultK2RcMap = GetKeyToResCandidateMap( defaultContext );
            var defaultValues = GetValuesFrom( defaultK2RcMap, rc => rc != null ).ToList();

            Assert.IsTrue( defaultValues.Count > 0 );
            CollectionAssert.AllItemsAreNotNull( defaultValues );
            CollectionAssert.DoesNotContain( defaultValues, String.Empty, NOT_NONE_EMPTY_MESSAGE );
        }


        [TestMethod]
        public void Localization_deDE_NotEmptyAndNoneNullAndNoneEmpty()
        {
            var deDeContext = CreateSingleLanguageContext( CULTURE_GERMAN );
            var deDeK2RcMap = GetKeyToResCandidateMap( deDeContext );
            var deDeValues = GetValuesFrom( deDeK2RcMap, rc => !rc.IsDefault ).ToList();

            Assert.IsTrue( deDeValues.Count > 0 );
            CollectionAssert.AllItemsAreNotNull( deDeValues );
            CollectionAssert.DoesNotContain( deDeValues, String.Empty, NOT_NONE_EMPTY_MESSAGE );
        }



        private static ResourceContext CreateSingleLanguageContext( string locale )
        {
            var languages = new List<string> { locale };
            var context = new ResourceContext() { Languages = languages };
            return context;
        }


        private static IEnumerable<string> GetKeysFrom 
            ( IEnumerable<Tuple<string, ResourceCandidate>> keyToCandiateMap, 
              Func<ResourceCandidate, bool> filter )
        {
            IEnumerable<string> keys = null;

            keys = keyToCandiateMap 
                .Where( tpl => filter( tpl.Item2 ) ) 
                .Select( tpl => tpl.Item1 ) 
                .ToList();

            return keys;
        }


        private static IEnumerable<Tuple<string, ResourceCandidate>> GetKeyToResCandidateMap 
            ( ResourceContext context )
        {
            IEnumerable<Tuple<string, ResourceCandidate>> map = null;

            var resw = GetResourceMap();
            var allKeys = resw.Keys.ToList();
            map = allKeys.Select( k => Tuple.Create( k, resw.GetValue( k, context ) ) ).ToList();

            return map;
        }


        //  --> based on https://stackoverflow.com/questions/10800730/resourcemap-not-found-error-when-referencing-a-resource-file-within-a-portable-c
        private static ResourceMap GetResourceMap()
        {
            string assemblyNamespace = "XElement.RYB.UI.UWP.Localization";
            string reswFileName = "Locale";
            string reference = $"{assemblyNamespace}/{reswFileName}";
            var resourceMap = ResourceManager.Current.MainResourceMap.GetSubtree( reference );
            return resourceMap;
        }


        private static IEnumerable<string> GetValuesFrom
            ( IEnumerable<Tuple<string, ResourceCandidate>> keyToCandiateMap,
              Func<ResourceCandidate, bool> filter )
        {
            IEnumerable<string> values = null;

            values = keyToCandiateMap 
                .Where( tpl => filter( tpl.Item2 ) ) 
                .Select( tpl => tpl.Item2.ValueAsString ) 
                .ToList();

            return values;
        }


        private const string CULTURE_GERMAN = "de-DE";//TODO: Is there any predefined, i.e., framework const?

        private const string NOT_NONE_EMPTY_MESSAGE = "At least one entry is equals to 'String.Empty'.";
    }
}
