namespace Entidades
{
    public class Login
    {
        private string _Id;
        private string _User;
        private string _Password;
        private string _Nivel;

        public string Id { get => _Id; set => _Id = value; }
        public string User { get => _User; set => _User = value; }
        public string Password { get => _Password; set => _Password = value; }
        public string Nivel { get => _Nivel; set => _Nivel = value; }
    }
}
