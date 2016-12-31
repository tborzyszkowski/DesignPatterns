using System.Dynamic;

namespace DynamicProxy
{
    public class DynamicProxy : DynamicObject, IOtherInterface
    {
        private readonly ISomeInterface _target;

        public DynamicProxy(ISomeInterface target)
        {
            _target = target;
        }

        public string Method3()
        {
            return this.GetType().Name + ": Tu metoda nr 3!";
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                result = _target.GetType().GetMethod(binder.Name).Invoke(_target, args);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}