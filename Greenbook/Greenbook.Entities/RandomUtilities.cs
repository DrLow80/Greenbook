using System;
using System.Collections.Generic;
using System.Linq;

namespace Greenbook.Entities
{
    public class RandomUtilities
    {
        private static readonly string[] LipsumData =
        {
            "a",
            "ac",
            "accumsan",
            "ad",
            "adipiscing",
            "aenean",
            "aliquam",
            "aliquet",
            "amet",
            "ante",
            "aptent",
            "arcu",
            "at",
            "auctor",
            "augue",
            "bibendum",
            "blandit",
            "class",
            "commodo",
            "condimentum",
            "congue",
            "consectetur",
            "consequat",
            "conubia",
            "convallis",
            "cras",
            "cubilia",
            "curabitur",
            "curae",
            "cursus",
            "dapibus",
            "diam",
            "dictum",
            "dictumst",
            "dignissim",
            "dis",
            "dolor",
            "donec",
            "dui",
            "duis",
            "efficitur",
            "egestas",
            "eget",
            "eleifend",
            "elementum",
            "elit",
            "enim",
            "erat",
            "eros",
            "est",
            "et",
            "etiam",
            "eu",
            "euismod",
            "ex",
            "facilisi",
            "facilisis",
            "fames",
            "faucibus",
            "felis",
            "fermentum",
            "feugiat",
            "finibus",
            "fringilla",
            "fusce",
            "gravida",
            "habitant",
            "habitasse",
            "hac",
            "hendrerit",
            "himenaeos",
            "iaculis",
            "id",
            "imperdiet",
            "in",
            "inceptos",
            "integer",
            "interdum",
            "ipsum",
            "justo",
            "lacinia",
            "lacus",
            "laoreet",
            "lectus",
            "leo",
            "libero",
            "ligula",
            "litora",
            "lobortis",
            "lorem",
            "luctus",
            "maecenas",
            "magna",
            "magnis",
            "malesuada",
            "massa",
            "mattis",
            "mauris",
            "maximus",
            "metus",
            "mi",
            "molestie",
            "mollis",
            "montes",
            "morbi",
            "mus",
            "nam",
            "nascetur",
            "natoque",
            "nec",
            "neque",
            "netus",
            "nibh",
            "nisi",
            "nisl",
            "non",
            "nostra",
            "nulla",
            "nullam",
            "nunc",
            "odio",
            "orci",
            "ornare",
            "parturient",
            "pellentesque",
            "penatibus",
            "per",
            "pharetra",
            "phasellus",
            "placerat",
            "platea",
            "porta",
            "porttitor",
            "posuere",
            "potenti",
            "praesent",
            "pretium",
            "primis",
            "proin",
            "pulvinar",
            "purus",
            "quam",
            "quis",
            "quisque",
            "rhoncus",
            "ridiculus",
            "risus",
            "rutrum",
            "sagittis",
            "sapien",
            "scelerisque",
            "sed",
            "sem",
            "semper",
            "senectus",
            "sit",
            "sociis",
            "sociosqu",
            "sodales",
            "sollicitudin",
            "suscipit",
            "suspendisse",
            "taciti",
            "tellus",
            "tempor",
            "tempus",
            "tincidunt",
            "torquent",
            "tortor",
            "tristique",
            "turpis",
            "ullamcorper",
            "ultrices",
            "ultricies",
            "urna",
            "ut",
            "varius",
            "vehicula",
            "vel",
            "velit",
            "venenatis",
            "vestibulum",
            "vitae",
            "vivamus",
            "viverra",
            "volutpat",
            "vulputate"
        };

        private static readonly Random RandomInstance = new Random();

        public static int RandomInt(int min, int max)
        {
            return min == max
                ? min
                : RandomInstance.Next(min, max);
        }

        public static IEnumerable<T> RandomList<T>(int min, int max, Func<T> randomFunc)
        {
            var list = new List<T>();

            var amount = RandomInt(min, max);

            for (var i = 0; i < amount; i++)
                list.Add(randomFunc());

            return list;
        }

        public static Session RandomSession()
        {
            return new Session()
            {
                Name = RandomName(),
                Encounters = RandomList(3, 5, RandomEncounter).ToList()
            };
        }

        public static ContentItem RandomContentItem()
        {
            return new ContentItem
            {
                Description = RandomDescription(),
                Id = Guid.NewGuid(),
                Name = RandomName(),
                Encounters = RandomList(3, 5, RandomEncounter).ToList()
            };
        }

        private static string RandomDescription()
        {
            return string.Join(" ", RandomList(10, 100, RandomLipsum));
        }

        private static string RandomLipsum()
        {
            var result = RandomInt(0, LipsumData.Length);

            return LipsumData[result];
        }

        private static string RandomName()
        {
            return string.Join(" ", RandomList(1, 5, RandomLipsum));
        }

        public static Encounter RandomEncounter()
        {
            return new Encounter
            {
                Id = Guid.NewGuid(),
                Name = RandomName(),
                Description = RandomDescription(),
            };
        }

        private static bool RandomBool()
        {
            return RandomInt(1, 10) % 5 == 0;
        }
    }
}