# SharpTrends
A .NET Standard 2.1 API for GoogleTrends

# Requirements
Built on .NET Standard 2.1, this library is able to be used cross-platform. 

However, your application will need to support .NET Standard 2.1. We recommend targeting the .NET 5.0 Framework. 

For more information, see [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

# Installation
[Install using NuGet Package Manger](https://docs.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio) or download and build manually, and include the `.dll`


# Dependencies
(these are handled automatically)
- [NewtonSoft 12.0.3](https://www.newtonsoft.com/json) - Used for JSON Parsing
- [GoogleTrends](https://trends.google.com/trends/) (as of 2021-03-12)

# Usage
The core class through which the API can be accessed is `SharpTrends.Client`
```csharp
using SharpTrends;
using SharpTrends.DailyTrends;

namespace Examples
{
    class DailyTrends 
    {         
        static void Main(string[] args)
        {
            var client = new SharpTrends.Client();

            List<TrendingSearch> data = client.DailyTrends();
            
            foreach (var i in data)
            {
                Console.WriteLine($"{i.Title}:" +
                    $"\n\tDate:\t{i.Date}" +
                    $"\n\tTraffic:\t{i.Traffic:E2}" +
                    $"\n\tRelated:\t{String.Join(", ", i.RelatedQueries)}" +
                    $"\n\tArticles:\t{i.Articles.Count}");
            }
        }
    }
}
```

For more information see the [Wiki](https://github.com/samueldonovan1701/SharpTrends/wiki) and [Examples](https://github.com/samueldonovan1701/SharpTrends/edit/main/Examples/)

# Resources

Project Website: http://samueldonovan1701.github.io/SharpTrends

Github: https://github.com/samueldonovan1701/SharpTrends

Wiki: https://github.com/samueldonovan1701/SharpTrends/wiki

Report a bug: https://github.com/samueldonovan1701/SharpTrends/issues

Discuss: https://github.com/samueldonovan1701/SharpTrends/discussions

NuGet: https://www.nuget.org/packages/SharpTrends/


# License
SharpTrends is licensed under a [MIT License](https://github.com/samueldonovan1701/SharpTrends/edit/main/LICENSE.txt)

# Author
Samuel S. Donovan

samuel.donovan1701@gmail.com

https://github.com/samueldonovan1701


# TODO
- Examples
  - Add RealTimeTrends Example
  - Add YearInSearch Example
  - Add Widget examples
- Wiki
	- Back-end documentation
- Project Website
	- GeoCodes search
	- ExploreCategories search
	- YIS Valid years lookup
