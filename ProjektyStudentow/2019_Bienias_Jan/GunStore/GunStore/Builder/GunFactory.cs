using GunStore.Singleton;

namespace GunStore.Builder
{
    //Builder Director
    public class GunFactory : Singleton<GunFactory>
    {
        private GunFactory() { }

        public Gun Construct(GunBuilder gunBuilder)
        {
            return gunBuilder;
        }
    }
}
