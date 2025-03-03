using PhrasalVerbs.Application.Models;

namespace PhrasalVerbs.Application.Data;

public class PhrasalVerbsSeeder : IPhrasalVerbsSeeder
{
    public PhrasalVerb[] GetPharsalVerbs()
    {
        List<PhrasalVerb> phrasalVerbs = new List<PhrasalVerb>
        {
            new PhrasalVerb { Id = new Guid(1.ToString("x32")), Verb = "Abide by" },
            new PhrasalVerb { Id = new Guid(2.ToString("x32")), Verb = "Account for" },
            new PhrasalVerb { Id = new Guid(3.ToString("x32")), Verb = "Ache for" },
            new PhrasalVerb { Id = new Guid(4.ToString("x32")), Verb = "Act on" },
            new PhrasalVerb { Id = new Guid(5.ToString("x32")), Verb = "Act out" },
            new PhrasalVerb { Id = new Guid(6.ToString("x32")), Verb = "Act up" },
            new PhrasalVerb { Id = new Guid(7.ToString("x32")), Verb = "Act upon" },
            new PhrasalVerb { Id = new Guid(8.ToString("x32")), Verb = "Add on" },
            new PhrasalVerb { Id = new Guid(9.ToString("x32")), Verb = "Add up" },
            new PhrasalVerb { Id = new Guid(10.ToString("x32")), Verb = "Add up to" },
            new PhrasalVerb { Id = new Guid(11.ToString("x32")), Verb = "Advise against" },
            new PhrasalVerb { Id = new Guid(12.ToString("x32")), Verb = "Agree with" },
            new PhrasalVerb { Id = new Guid(13.ToString("x32")), Verb = "Aim at" },
            new PhrasalVerb { Id = new Guid(14.ToString("x32")), Verb = "Allow for" },
            new PhrasalVerb { Id = new Guid(15.ToString("x32")), Verb = "Angle for" },
            new PhrasalVerb { Id = new Guid(16.ToString("x32")), Verb = "Answer back" },
            new PhrasalVerb { Id = new Guid(17.ToString("x32")), Verb = "Answer for" },
            new PhrasalVerb { Id = new Guid(18.ToString("x32")), Verb = "Argue down" },
            new PhrasalVerb { Id = new Guid(19.ToString("x32")), Verb = "Argue out" },
            new PhrasalVerb { Id = new Guid(20.ToString("x32")), Verb = "Ask about" },
        };

        return phrasalVerbs.ToArray();
    }

    public Translation[] GetTranslations()
    {
        List<Translation> translations = new List<Translation>
        {
            new Translation { Id = new Guid(1.ToString("x32")), PhrasalVerbId = new Guid(1.ToString("x32")), Language = "pl", Verb = "Zaakceptować lub postępować zgodnie z decyzją lub zasadą" },
            new Translation { Id = new Guid(2.ToString("x32")), PhrasalVerbId = new Guid(2.ToString("x32")), Language = "pl", Verb = "Wyjaśnić" },
            new Translation { Id = new Guid(3.ToString("x32")), PhrasalVerbId = new Guid(3.ToString("x32")), Language = "pl", Verb = "Bardzo czegoś lub kogoś chcieć" },
            new Translation { Id = new Guid(4.ToString("x32")), PhrasalVerbId = new Guid(4.ToString("x32")), Language = "pl", Verb = "Podjąć działania na podstawie otrzymanych informacji" },
            new Translation { Id = new Guid(5.ToString("x32")), PhrasalVerbId = new Guid(5.ToString("x32")), Language = "pl", Verb = "Odtworzyć coś za pomocą gestów" },
            new Translation { Id = new Guid(6.ToString("x32")), PhrasalVerbId = new Guid(6.ToString("x32")), Language = "pl", Verb = "Zachowywać się źle lub dziwnie" },
            new Translation { Id = new Guid(7.ToString("x32")), PhrasalVerbId = new Guid(7.ToString("x32")), Language = "pl", Verb = "Podjąć działania na podstawie otrzymanych informacji" },
            new Translation { Id = new Guid(8.ToString("x32")), PhrasalVerbId = new Guid(8.ToString("x32")), Language = "pl", Verb = "Dodać do obliczeń" },
            new Translation { Id = new Guid(9.ToString("x32")), PhrasalVerbId = new Guid(9.ToString("x32")), Language = "pl", Verb = "Dokonać matematycznego podsumowania" },
            new Translation { Id = new Guid(10.ToString("x32")), PhrasalVerbId = new Guid(10.ToString("x32")), Language = "pl", Verb = "Doprowadzić do" },
            new Translation { Id = new Guid(11.ToString("x32")), PhrasalVerbId = new Guid(11.ToString("x32")), Language = "pl", Verb = "Odradzać" },
            new Translation { Id = new Guid(12.ToString("x32")), PhrasalVerbId = new Guid(12.ToString("x32")), Language = "pl", Verb = "Zgadzać się z" },
            new Translation { Id = new Guid(13.ToString("x32")), PhrasalVerbId = new Guid(13.ToString("x32")), Language = "pl", Verb = "Celować w" },
            new Translation { Id = new Guid(14.ToString("x32")), PhrasalVerbId = new Guid(14.ToString("x32")), Language = "pl", Verb = "Uwzględniać" },
            new Translation { Id = new Guid(15.ToString("x32")), PhrasalVerbId = new Guid(15.ToString("x32")), Language = "pl", Verb = "Zabiegać o coś" },
            new Translation { Id = new Guid(16.ToString("x32")), PhrasalVerbId = new Guid(16.ToString("x32")), Language = "pl", Verb = "Odpyskować" },
            new Translation { Id = new Guid(17.ToString("x32")), PhrasalVerbId = new Guid(17.ToString("x32")), Language = "pl", Verb = "Odpowiadać za" },
            new Translation { Id = new Guid(18.ToString("x32")), PhrasalVerbId = new Guid(18.ToString("x32")), Language = "pl", Verb = "Przekonać kogoś do zmiany zdania" },
            new Translation { Id = new Guid(19.ToString("x32")), PhrasalVerbId = new Guid(19.ToString("x32")), Language = "pl", Verb = "Przedyskutować coś do końca" },
            new Translation { Id = new Guid(20.ToString("x32")), PhrasalVerbId = new Guid(20.ToString("x32")), Language = "pl", Verb = "Pytać o" },
        };

        return translations.ToArray();
    }
}