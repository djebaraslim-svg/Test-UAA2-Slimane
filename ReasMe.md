### ReadMe : UAA 2
### besoin métier
L' application fait une chose simple :
-Gérer des abonnements à une newsletter
-Envoyer un email quand quelqu’un s’abonne ou se désabonne
Un utilisateur donne son email choisit :
    -Nouveautés
    -Récap du mois
    -Fait du jour
-> peut modifier ses choix
-> peut se désinscrire
Donc le cœur métier = Subscriber

### Pourquoi on a séparé en couches ?
On a fait une Clean Architecture simplifiée :

WebAPI (Controllers) -> Application (Services + Interfaces)-> Domain (Entités métier) -> Infrastructure (EF Core + MailKit)

### Pourquoi ?
Parce que :
Le Domain ne doit dépendre de rien
L’Application contient la logique métier
L’Infrastructure gère les détails techniques (DB, SMTP)
La WebAPI expose l’HTTP
-> Ça rend le code testable, propre et évolutif.

### Le DOMAIN : le cœur
Subscriber
C’est le modèle métier.

public class Subscriber
Il contient :
    -Id
    -Email
    -3 booléens

->Pourquoi les booléens ?
Parce que notre besoin métier est simple : "Est-il abonné à x ? Oui ou non"
C’est plus simple qu’un Enum.

-> Pourquoi des méthodes comme UpdateSubscriptions ?
Parce qu’en Clean Architecture :
    -Le Domain doit protéger son état
    -On centralise la logique
    -Si demain on ajoute une règle métier, elle est ici
    -On évite des incohérences

### APPLICATION : la logique métier
ISubscriberRepository
Interface → contrat

Subscriber? GetByEmail(string email);
void Add(Subscriber subscriber);
void Update(Subscriber subscriber);
void Delete(Subscriber subscriber);
void Save();

-Pourquoi interface ?
Parce que le service métier ne doit pas dépendre d’Entity Framework.
Il dépend d’un contrat.
IMailerailService
Même principe.

Le service métier ne sait pas si on utilise :
    -MailKit
    -SendGrid
    -AWS
    -SMTP local

SubscriptionService = cerveau de l’application
C’est La classe la plus importante.

### Logique générale de l’application
L’application est une Web API qui permet de gérer l’abonnement à une newsletter. Lorsqu’un utilisateur appelle l’endpoint Subscribe, le contrôleur transmet la demande au SubscriptionService. Ce service vérifie d’abord si un abonné avec cet email existe déjà en base via le repository. S’il n’existe pas, un nouvel objet Subscriber est créé , s’il existe, ses préférences (ouveautés, Récap du mois, Fait du jour) sont mises à jour grâce à la méthode UpdateSubscriptions. Ensuite, les modifications sont sauvegardées en base de données avec Entity Framework, puis un email de confirmation est envoyé via MailKit. Pour la désinscription, la méthode Unsubscribe recherche l’abonné par email, le supprime complètement de la base (respect du droit à l’oubli), sauvegarde les changements et envoie un email de confirmation. L’architecture sépare clairement les responsabilités : le contrôleur gère l’HTTP, le service contient la logique métier, le repository gère l’accès aux données, et l’infrastructure s’occupe d’Entity Framework et de l’envoi des emails.


