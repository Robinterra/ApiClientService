Ein kleiner ApiClient zum ansprechen von Rest Apis. Mithilfe eines Interfaces ist der Api Client testable.

# Publish
`dotnet pack  -c Release -p:NuspecFile=.nuspec`
`dotnet nuget push -k 363f3d9a-2715-4064-b454-3cf261ef0731 -s http://cloud.versalitic.int:5555/v3/index.json .\ApiService.1.0.4.nupkg`