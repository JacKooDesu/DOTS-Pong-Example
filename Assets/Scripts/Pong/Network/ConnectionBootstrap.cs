using Unity.NetCode;

namespace Pong.Network
{
    public class ConnectionBootstrap : ClientServerBootstrap
    {
        public override bool Initialize(string defaultWorldName)
        {
            return false;
        }
    }
}
