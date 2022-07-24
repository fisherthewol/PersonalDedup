using System.Reflection;

namespace PersonalDedupeTest;

public class ImageDedupUnitTest
{
    /// <summary>
    /// Tests that two known-different images are marked as non-duplicate.
    /// </summary>
    /// <param name="image1">Filename of first image to test.</param>
    /// <param name="image2">Filename of second image to test.</param>
    [Theory]
    [InlineData("HNI_0063.JPG", "HNI_0064.JPG")]
    public void KnownDifferentImagesArentDuplicate(string image1, string image2)
    {
        var x = Assembly.GetExecutingAssembly().GetManifestResourceStream(image1) ?? throw new NullReferenceException($"image1 returned null. string: {image1}");
        var y = Assembly.GetExecutingAssembly().GetManifestResourceStream(image2) ?? throw new NullReferenceException($"image2 returned null. string: {image2}");;
        Assert.False(PersonalDedupeLib.IsImageDuplicate(x, y));
    }
}