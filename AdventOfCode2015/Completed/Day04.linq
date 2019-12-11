<Query Kind="Statements">
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

var key = "yzbqklnj";
var i = 0;
using (MD5 hash = MD5.Create())
{
	while (true)
	{
		var h = GetMd5Hash(hash, key + i);
		if (h.StartsWith("000000"))
		{
			h.Dump();
			i.Dump();
			break;
		}
		i++;
	}
}





static string GetMd5Hash(MD5 md5Hash, string input)
{

	// Convert the input string to a byte array and compute the hash.
	byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

	// Create a new Stringbuilder to collect the bytes
	// and create a string.
	StringBuilder sBuilder = new StringBuilder();

	// Loop through each byte of the hashed data 
	// and format each one as a hexadecimal string.
	for (int i = 0; i < data.Length; i++)
	{
		sBuilder.Append(data[i].ToString("x2"));
	}

	// Return the hexadecimal string.
	return sBuilder.ToString();
}