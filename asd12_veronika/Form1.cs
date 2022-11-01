namespace asd12_veronika;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var (text, textWhereFindString) = (richTextBox1.Text, richTextBox2.Text);

        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(textWhereFindString)) return;

        var smallestWithVowels = text.Split(' ').MinBy(CountOfVowel)!;
        label1.Text = $@"Smallest word: {smallestWithVowels}";

        var indexes = FindIndexesWithTime(textWhereFindString, smallestWithVowels);

        OutputText(textWhereFindString, smallestWithVowels, indexes);
    }

    private int[] FindIndexesWithTime(string textWhereFindString, string smallestWithVowels)
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        var indexes = BoyerMoore.SearchString(textWhereFindString, smallestWithVowels);
        watch.Stop();
        label2.Text = $@"Time: {watch.Elapsed}";

        return indexes;
    }

    private void OutputText(string textWhereFindString, string smallestWithVowels, int[] indexes)
    {
        richTextBox2.Clear();


        for (var i = 0; i < textWhereFindString.Length; i++)
        {
            if (indexes.Contains(i)) //������ ��������� � ������ , ������� ������� ��� ����� ���������� � ����� ������
            {
                SetColor(
                    textWhereFindString[i..(i + smallestWithVowels.Length)] // ������ �������� 
                    //textWhereFindString.AsSpan(i, smallestWithVowels.Length).ToString() //�������������� ������
                    );
                i += smallestWithVowels.Length - 1; // ��������� 1 , �� ���� ���� for ����������� ������� 1
                continue;
            }
            richTextBox2.AppendText(textWhereFindString[i].ToString());
        }
    }

    private void SetColor(string i)
    {
        richTextBox2.SelectionColor = Color.Red;
        richTextBox2.AppendText(i);
        richTextBox2.SelectionColor = Color.Black;
    }
    private int CountOfVowel(string s) => s.Count(ch => ch.IsVowel());
}