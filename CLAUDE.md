# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Solution layout

```
src/HuffmanWeb/
├── HuffmanWeb.slnx                  # Solution file (new .NET slnx format)
├── Directory.Packages.props         # Central Package Management — all NuGet versions live here
├── HuffmanWeb.Common/               # Shared DTOs, requests, responses (no dependencies)
├── HuffmanWeb.Algorithm/            # Huffman algorithm logic (depends on Common)
├── HuffmanWeb.Server/               # ASP.NET minimal API + React SPA host (depends on Algorithm + Common)
├── HuffmanWeb.UnitTests/            # xUnit tests for algorithm layer (depends on Algorithm + Common)
├── HuffmanWeb.Mobile.Client/        # .NET MAUI app — Android + macCatalyst (depends on Common only)
└── huffmanweb.client/               # React + TypeScript SPA (Vite, MUI, Vitest)
```

## Commands

All .NET commands run from the repo root.

```bash
# Build entire solution
dotnet build src/HuffmanWeb/HuffmanWeb.slnx

# Run all tests
dotnet test src/HuffmanWeb/HuffmanWeb.UnitTests/HuffmanWeb.UnitTests.csproj

# Run a single test by name
dotnet test src/HuffmanWeb/HuffmanWeb.UnitTests/HuffmanWeb.UnitTests.csproj --filter "FullyQualifiedName~MethodName"

# Run the web server (starts Vite proxy automatically in dev)
dotnet run --project src/HuffmanWeb/HuffmanWeb.Server/HuffmanWeb.Server.csproj
```

Frontend (run from `src/HuffmanWeb/huffmanweb.client/`):

```bash
npm run dev          # Vite dev server (port 5174, proxied by the .NET server in dev)
npm run build        # TypeScript compile + Vite build
npm run lint         # ESLint
npm test             # Vitest (watch mode)
npm run test:coverage
```

MAUI mobile builds require platform SDKs (Android/macCatalyst). The mobile project targets `net10.0-android` and `net10.0-maccatalyst`.

## Architecture

### Server + SPA

The ASP.NET minimal API (`Program.cs`) serves as both the API backend and the host for the React SPA. In development, `SpaProxy` forwards non-API requests to the Vite server on `https://localhost:5174`. In production, the built React output is served as static files. The API exposes two endpoints:

- `POST /huffman/encode` — accepts `EncodeRequest`, returns `EncodeResponse` (graph + binary string + matching table)
- `POST /huffman/decode` — accepts `DecodeRequest` (binary string + matching table), returns decoded text

All business logic is currently inline in `Program.cs` lambdas — there is no service layer between HTTP handling and the algorithm.

### Algorithm layer

`Huffman.cs` and `Algorithms.cs` are **static classes**. `Huffman` orchestrates the pipeline; `Algorithms` contains only `DFS`. The algorithm uses `Dictionary<char, string>` throughout. `WeightedGraphExtensions.cs` adds `ComputeDescendants()` as an extension method, called by the server after building the graph to populate `DescendantsCount` on each node for the tree renderer.

### Mobile client (MAUI)

The mobile app calls the production API at `https://huffmanweb.thognard.net/huffman` via Refit. ViewModels use `CommunityToolkit.Mvvm` with `[ObservableProperty]` on `partial class` types inheriting `BaseViewModel : ObservableObject`. **Exception:** `EncodeTreeViewModel` manually implements `INotifyPropertyChanged` and does not inherit `BaseViewModel` — do not follow this pattern for new ViewModels.

Pages resolve their ViewModels via `IPlatformApplication.Current?.Services.GetService<T>()` in their constructors (Service Locator). The `IHuffmanApi` Refit client is instantiated directly inside each ViewModel, not injected via DI.

### React frontend

The SPA mirrors the server DTOs in `src/dtos/`. API calls go through `src/utils/apiClient.ts`. Components under `src/components/` are split by feature (`Encode/`, `Decode/`, `Layout/`, `UI/`). Tests use Vitest + Testing Library.

## Notes

- **Package versions**: All NuGet versions are centrally managed in `Directory.Packages.props`. Adding a new package reference in a `.csproj` must omit the `Version` attribute; version goes in `Directory.Packages.props` only.
