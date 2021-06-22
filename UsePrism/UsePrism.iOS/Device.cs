using UsePrism.Objects;

[assembly: Xamarin.Forms.Dependency(typeof(UsePrism.iOS.Device))]
namespace UsePrism.iOS
{
    internal sealed class Device : IDevice
    {
        public string GetDeviceName()
        {
            return "iOS";
        }
    }
}