# Frontend Tests Integration for CI/CD Pipeline

## Overview
This document provides instructions for integrating the frontend tests into the CI/CD pipeline so SonarQube can analyze the test coverage.

## Configuration Complete

The following has been configured in the `huffmanweb.client` project:

### 1. Test Coverage Configuration
- **File**: `vitest.config.ts`
- **Coverage Provider**: v8
- **Output Format**: LCOV (compatible with SonarQube)
- **Coverage Directory**: `./coverage`

### 2. NPM Scripts
```json
"test": "vitest",
"test:ui": "vitest --ui",
"test:coverage": "vitest run --coverage"
```

## Pipeline Integration Complete

The frontend tests have been integrated into the CI/CD pipeline in `.github/workflows/CICD.yaml`. The pipeline now:

1. **Sets up Node.js 20.x** with npm caching for faster builds
2. **Installs frontend dependencies** using `npm ci` in the `huffmanweb.client` directory
3. **Runs frontend tests with coverage** using `npm run test:coverage`
4. **Reports coverage to SonarQube** via LCOV format at `src/HuffmanWeb/huffmanweb.client/coverage/lcov.info`

### Implementation Details

The following steps were added to the `analyze` job in CICD.yaml:

```yaml
- name: Setup Node.js
  uses: actions/setup-node@v3
  with:
    node-version: '20.x'
    cache: 'npm'

```yaml
/d:sonar.javascript.lcov.reportPaths=src/HuffmanWeb/huffmanweb.client/coverage/lcov.info
/d:sonar.typescript.lcov.reportPaths=src/HuffmanWeb/huffmanweb.client/coverage/lcov.info
```

## Local Testing

To verify coverage generation locally:

```bash
cd src/HuffmanWeb/huffmanweb.client
npm run test:coverage
```

This will:
1. Run all tests
2. Generate coverage reports in `./coverage/`
3. Create `lcov.info` for SonarQube
4. Create HTML report in `./coverage/index.html`

## Coverage Metrics

Current test coverage:
- **SteampunkButton**: 8 tests
- **SteampunkLayout**: 6 tests
- **Total**: 14 tests

## Notes

- The TypeScript lint error in `vitest.config.ts` is a known version mismatch between Vite and Vitest's bundled Vite. It doesn't affect functionality.
- Coverage reports are excluded from git via `.gitignore`
- The LCOV format is industry-standard and compatible with SonarQube, Codecov, and Coveralls
