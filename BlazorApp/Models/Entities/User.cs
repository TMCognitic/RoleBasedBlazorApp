namespace BlazorApp.Models.Entities
{
    public class User
    {
        public int Id { get; }
        public string Nom { get; }
        public string Prenom { get; }
        public string NomComplet { get { return $"{Prenom} {Nom}"; } }
        public string Email { get; }
        public string Role { get; }
        public User(int id, string nom, string prenom, string email, string role)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Role = role;
        }
    }
}
