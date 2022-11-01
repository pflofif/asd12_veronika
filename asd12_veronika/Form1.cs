namespace asd12_veronika;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var text = richTextBox1.Text;
        var textWhereFindString = richTextBox2.Text;
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(textWhereFindString)) return;

        var smallestWithVowels = text.Split(' ').MinBy(CountOfVowel)!;
        label1.Text = $@"Smallest word: {smallestWithVowels}";

        var indexes = BoyerMoore.SearchString(textWhereFindString, smallestWithVowels);

        OutputText(textWhereFindString, smallestWithVowels, indexes);
    }

    private void OutputText(string textWhereFindString, string smallestWithVowels, int[] indexes)
    {
        richTextBox2.Clear();
        for (int i = 0; i < textWhereFindString.Length; i++)
        {
            if (indexes.Contains(i)) //індекс знаходить в масивів , значить потірбне нам слово починається з цього інекса
            {
                for (int j = i; j < i + smallestWithVowels.Length; j++)// виводимо потрібне нам слово 
                {
                    SetColor(textWhereFindString[j]);
                }
                i += smallestWithVowels.Length - 1;
                continue;
            }
            richTextBox2.AppendText(textWhereFindString[i].ToString());
        }
    }

    private void SetColor(char i)
    {
        richTextBox2.SelectionColor = Color.Red;
        richTextBox2.AppendText(i.ToString());
        richTextBox2.SelectionColor = Color.Black;
    }
    private int CountOfVowel(string s) => s.Count(ch => ch.IsVowel());
}