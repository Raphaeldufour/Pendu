Random random = new Random();
string[] words = System.IO.File.ReadAllLines(@"C:\Users\rapha\source\repos\PenduGroupe1\PenduGroupe1\TextFile1.txt");
int rnd = random.Next(words.Count());
string mot = words[rnd].ToUpper();
mot = mot.Replace("É", "E");
mot = mot.Replace("È", "E");
mot = mot.Replace("Ê", "E");
mot = mot.Replace("Ë", "E");
char[] MotATrouvée = new char[mot.Length];
char[] mauvaiseslettres = new char[26];
int L = 0;
int erreur = 0;
int nombreDEssais=6;
string lettres = "";

Console.WriteLine("Essaie de trouver le mot ");
for (int i = 0; i < mot.Length; i++)
{
	MotATrouvée[i] = '_';
	if (mot[i]=='\''|| mot[i]=='-')
	{
		MotATrouvée[i] = mot[i];
	}
}
Console.WriteLine(MotATrouvée);
while (string.Join("", MotATrouvée) != mot && erreur < nombreDEssais)
{
	lettres = (Console.ReadLine().ToUpper());
	Console.Clear();
	if (mot==lettres)
	{
		lettres = MotATrouvée.ToString();
		break;
	}
	try
	{
		for (int i = 0; i < mot.Length; i++)
		{
			if (char.Parse(lettres) == mot[i])
			{
				MotATrouvée[i] = char.Parse(lettres);
			}
		}
	}
	catch
	{
		Console.WriteLine("mauvais mot");
	}
	Console.WriteLine(MotATrouvée);
	if (mot.Contains(lettres))
	{
		Console.WriteLine("La lettre était dans le mot");
	}
	else
	{
		Console.WriteLine("La lettre n'était pas dans le mot");
		if (mauvaiseslettres.Contains(char.Parse(lettres)))
		{
			Console.WriteLine("ta déjà essayé");
		}
		else
		{
			mauvaiseslettres[L] = char.Parse(lettres);
			L++;
			nombreDEssais--;
		}
	}
	Console.Write("Mauvaises lettres: ");
	foreach (char item in mauvaiseslettres)
	{
		Console.Write(item + " ");
	}
	Console.WriteLine($"il vous reste {nombreDEssais} essais");
	Console.WriteLine();
	}
if (nombreDEssais==0)
{
	Console.WriteLine("TU AS PERDU SALE MERDE");
}
if (string.Join("", MotATrouvée) == mot||lettres==mot)
{
	Console.WriteLine("TU AS GAGNEE");
}
Console.WriteLine("le mot était "+ mot);