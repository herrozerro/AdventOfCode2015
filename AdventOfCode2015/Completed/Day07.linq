<Query Kind="Program" />

void Main()
{
	Directory.SetCurrentDirectory(Path.GetDirectoryName(Util.CurrentQueryPath));

	var s = File.ReadAllLines("..\\Data\\Day07.txt");

	List<circuit> ls = new List<UserQuery.circuit>();

	foreach (var l in s)
	{


		var parts = l.Split(" ");

		if (parts.Last() == "f")
		{
			//1.Dump();
		}

		var c = new circuit();
		if (l.Contains("AND") || l.Contains("OR") || l.Contains("LSHIFT") || l.Contains("RSHIFT"))
		{
			c.ID = parts[4];
			c.OPERATOR = parts[1];
			c.input1String = parts[0];
			c.input2String = parts[2];
			c.inputsNeeded = 2;

			c.output = 0;
		}
		else if (l.Contains("NOT"))
		{
			c.ID = parts[3];
			c.OPERATOR = parts[0];
			c.input1String = parts[1];
			c.inputsNeeded = 1;
			c.input2String = "-";

			c.output = 0;
		}
		else
		{
			c.ID = parts[2];
			c.complete = false;
			c.input1String = parts[0];
			c.input2String = "-";
			c.inputsNeeded = 1;
		}

		ls.Add(c);
	}

	//ls.Dump();

	while (ls.Any(l => l.complete == false))
	{


		//Util.ClearResults();
		//ls.Dump();
		for (int i = 0; i < ls.Count(); i++)
		{
			var l = ls[i];

			if (l.ID == "f")
			{
				//1.Dump();
			}

			if (l.complete)
			{
				continue;
			}

			if (l.inputsComplete)
			{
				switch (l.OPERATOR)
				{
					case "AND":
						l.output = AND(l.input1, l.input2);
						break;
					case "NOT":
						l.output = NOT(l.input1);
						break;
					case "OR":
						l.output = OR(l.input1, l.input2);
						break;
					case "LSHIFT":
						l.output = LSHIFT(l.input1, (int)l.input2);
						break;
					case "RSHIFT":
						l.output = RSHIFT(l.input1, (int)l.input2);
						break;
					default:
						l.output = l.input1;
						break;
				}
				l.complete = true;
			}
			else
			{
				if (l.input1String != "-")
				{
					var lst = ls.FirstOrDefault(x => x.ID == l.input1String);
					if (lst == null)
					{
						l.input1 = uint.Parse(l.input1String);
						l.input1String = "-";
					}
					else if (lst.complete)
					{
						l.input1 = lst.output;
						l.input1String = "-";
					}
				}
				if (l.input2String != "-")
				{
					var lst = ls.FirstOrDefault(x => x.ID == l.input2String);
					if (lst == null)
					{
						l.input2 = uint.Parse(l.input2String);
						l.input2String = "-";
					}
					else if (lst.complete)
					{
						l.input2 = lst.output;
						l.input2String = "-";
					}
				}
			}
		}
	}
	ls.Select(l => new { id = l.ID, o = l.output }).OrderBy(l => l.id).ToList().Dump();
}

class circuit
{
	public string ID { get; set; }
	public string OPERATOR { get; set; }

	public uint output { get; set; }

	public bool complete { get; set; } = false;

	public string input1String { get; set; }
	public uint input1
	{
		get; set;
	}
	public string input2String { get; set; }
	public uint input2
	{
		get; set;
	}

	public bool inputsComplete
	{
		get
		{
			bool iC = false;
			if (inputsNeeded == 0)
			{
				iC = true;
			}
			if (inputsNeeded == 1)
			{
				iC = input1String == "-";
			}
			if (inputsNeeded == 2)
			{
				iC = (input1String == "-") && (input2String == "-");
			}
			return iC;
		}
	}

	public int inputsNeeded { get; set; }
}


uint NOT(uint x)
{
	return (UInt16)(~x);
}

uint AND(uint x, uint y)
{
	return (x & y);
}

uint OR(uint x, uint y)
{
	return (x | y);
}

uint LSHIFT(uint x, int y)
{
	return (x << y);
}

uint RSHIFT(uint x, int y)
{
	return (x >> y);
}