using UsePrism.Objects;

[assembly: Xamarin.Forms.Dependency(typeof(UsePrism.Droid.Device))]
namespace UsePrism.Droid
{
    internal sealed class Device : IDevice
    {
        public string GetDeviceName()
        {
            return "Android";
        }
    }
}
