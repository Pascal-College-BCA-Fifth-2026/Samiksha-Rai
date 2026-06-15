using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace CounterApp.Pages
{
    public class CounterModel : PageModel
    {
        [BindProperty]
        public string InputText { get; set; } = string.Empty;

        public int CharacterCount { get; set; }
        public int WordCount { get; set; }
        public int SentenceCount { get; set; }
        public int VowelCount { get; set; }
        public int SpecialCharacterCount { get; set; }

        public bool IsSubmitted { get; set; }

        public void OnGet()
        {
            InputText = """
                Once upon a time, in a land far, far away, there lived a brave knight named Sir Lancelot.
                He was known throughout the kingdom for his courage and chivalry. One day, he embarked on a
                quest to rescue a princess from a fearsome dragon. With his trusty sword and unwavering determination,
                Sir Lancelot faced the dragon in an epic battle. After a fierce fight, he emerged victorious and
                saved the princess, earning the admiration of all who heard his tale.

                The grateful king rewarded Sir Lancelot with lands and treasures beyond measure. The princess,
                impressed by his valor, soon fell in love with the noble knight. They were married in a grand
                ceremony attended by lords and ladies from across the realm. Sir Lancelot and his beloved princess
                lived happily ever after in a magnificent castle, where they ruled with wisdom and kindness.
                Their legacy became the stuff of legend, inspiring generations of knights to pursue honor,
                courage, and true love.
                """;
        }

        public void OnPost()
        {
            IsSubmitted = true;

            CharacterCount = InputText.Length;

            WordCount = Regex.Matches(InputText, @"\b\w+\b").Count;

            SentenceCount = Regex.Matches(InputText, @"[.!?]").Count;

            VowelCount = Regex.Matches(InputText, "[aeiouAEIOU]").Count;

            SpecialCharacterCount =
                Regex.Matches(InputText, @"[^a-zA-Z0-9\s]").Count;
        }
    }
}