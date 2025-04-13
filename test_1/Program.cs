using test_1;

compressor comm = new compressor();

string short_st = comm.compression("aaabbcccdde");
string full_st = comm.decompression("a3b2c3d2e");
Console.WriteLine($"компрессия строки: {short_st}");
Console.WriteLine($"декомпрессия строки: {full_st}");
