using System.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.RedYellowBlue.FritzBoxAPI.ApiAdapter;

namespace XElement.RedYellowBlue.UI.UWP.Modules.AhaDevice
{
#region not unit-tested
    [Shared] [Export( typeof( IFactory<Model, IDevice> ) )]
    internal class ModelFactory : IFactory<Model, IDevice>
    {
        [ImportingConstructor]
        public ModelFactory() { }


        public Model /*IFactoryT2.*/Get( IDevice parameter )
        {
            return new Model( parameter );
        }
    }
#endregion
}
