using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class DescriptorTest
{

    [Test]
    public void CreateDescriptorTest()
    {
        Assert.DoesNotThrow(() => { new Descriptor("root"); });
    }

    [Test]
    public void CreateSubdescriptorTest()
    {
        Descriptor r = new Descriptor("root");
        Assert.DoesNotThrow(() => { new Descriptor("sub", r); });
    }

    [Test]
    public void ContainsSelfTest()
    {
        Descriptor r = new Descriptor("root");
        Assert.True(r.Contains(r));
    }

    [Test]
    public void ContainsSubdescriptorTest()
    {
        Descriptor r = new Descriptor("root");
        Descriptor s = new Descriptor("sub", r);
        Assert.True(r.Contains(s));
    }

    [Test]
    public void NotContainsSubdescriptorTest()
    {
        Descriptor r = new Descriptor("root");
        Descriptor s = new Descriptor("sub", r);
        Assert.False(s.Contains(r));
    }

    [Test]
    public void NotContainsDescriptorTest()
    {
        Descriptor r = new Descriptor("root");
        Descriptor o = new Descriptor("other");
        Assert.False(r.Contains(o));
    }
}
