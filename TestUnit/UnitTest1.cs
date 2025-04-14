using ex_2;
using ex_3;
using NUnit.Framework;
using test_1;

namespace TestUnit;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        ResetForTest();
    }
    
    [Test]
    public void compression_test()
    {
        compressor comm = new compressor();
        string st = comm.compression("aaabbcccdde");
        Assert.AreEqual(st, "a3b2c3d2e");

    }
    
    [Test]
    public void decompression_test()
    {
        compressor comm = new compressor();

        string st = comm.decompression("a3b2c3d2e");
        Assert.AreEqual(st, "aaabbcccdde");

    }
    

    [Test]
    public void WriteQueue_test()
    {
        // Arrange
        int before = Server.GetCount();

        // Act
        Server.AddCount(10);
        Server.AddCount(5);
        Server.WaitForWritesComplete();
        Thread.Sleep(1500);
        
        // Assert
        int after = Server.GetCount();
        Assert.AreEqual(before + 15, after);
    }
    
    public static void ResetForTest()
    {
        Server.WaitForWritesComplete();
        Server.WriteQueue.Add(() => Server._count = 0);
        Server.WaitForWritesComplete();
    }
    
    
    
    [Test]
    public void TryParseLogLine_test()
    {
        string validLine = "10.03.2025 15:14:49.523 INFORMATION  Версия программы: '3.4.0.48729'";
        bool result = TryParseLogLine(validLine, out var entry);
        
        Assert.IsTrue(result);
        Assert.IsNotNull(entry);
    }
    
    [Test]
    public void TryParseLogLineInvalid_test()
    {
        string validLine = "2025-03-10 .5882| WAputer.GetDevод устрO-M40-D-410244015546'";
        bool result = TryParseLogLine(validLine, out var entry);
        
        Assert.IsFalse(result);
        Assert.IsNull(entry);
    }
    
    
    [Test]
    public void ParseFromLogLine_test()
    {
        string validLine = "10.03.2025 15:14:49.523 INFORMATION  Версия программы: '3.4.0.48729'";
        bool result = TryParseLogLine(validLine, out var entry);
        
        Assert.IsTrue(result);
        Assert.AreEqual(entry.ToString(), "10.03.2025  15:14:49.523  INFO  DEFAULT  Версия программы: '3.4.0.48729'");
    }
    
    
    bool TryParseLogLine(string line, out InfoObj entry)
    {
        try
        {
            entry = InfoObj.ParseFromLogLine(line);
            return true;
        }
        catch (Exception ex)
        {
            entry = null;
            return false;
        }
    }

    bool TryParseStructuredLog(string line, out InfoObj entry)
    {
        try
        {
            entry = InfoObj.ParseFromStructuredLog(line);
            return true;
        }
        catch (Exception ex)
        {
            entry = null;
            return false;
        }
    }
    
    
    
    
    
    
}