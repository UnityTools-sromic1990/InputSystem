using System.Runtime.InteropServices;
using UnityEngine.Experimental.Input.Utilities;
using UnityEngine.Experimental.Input.LowLevel;

namespace UnityEngine.Experimental.Input.Plugins.XR.Haptics
{
    /// <summary>
    /// An IOCTL command sent to a device to set it's motor rumble intensity.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = kSize)]
    public struct SimpleXRRumbleCommand : IInputDeviceCommandInfo
    {
        static FourCC Type { get { return new FourCC('X', 'R', 'R', '0'); } }

        const int kSize = InputDeviceCommand.kBaseCommandSize + sizeof(float);

        [FieldOffset(0)]
        InputDeviceCommand baseCommand;

        [FieldOffset(InputDeviceCommand.kBaseCommandSize)]
        float intensity;

        public FourCC GetTypeStatic()
        {
            return Type;
        }

        /// <summary>
        /// Creates an IOCTL command that can then be sent to a specific device.
        /// </summary>
        /// <param name="motorIntensity">The desired motor intensity that should be within a [0-1] range.</param>
        /// <returns></returns>
        public static SimpleXRRumbleCommand Create(float motorIntensity)
        {
            return new SimpleXRRumbleCommand
            {
                baseCommand = new InputDeviceCommand(Type, kSize),
                intensity = motorIntensity
            };
        }
    }
}
