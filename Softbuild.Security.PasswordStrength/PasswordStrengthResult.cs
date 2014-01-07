
namespace Softbuild.Security
{
    public class PasswordStrengthResult
    {
        public PasswordStrengthResult()
        {
            this.Valid = false;
            this.Complexity = 0.0f;
        }

        public bool Valid { get; set; }

        public float Complexity { get; set; }
    }
}
