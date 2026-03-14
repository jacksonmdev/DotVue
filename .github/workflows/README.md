# GitHub Workflows

## Overview

This project uses reusable workflow templates following a CI/CD pipeline pattern.

| File | Purpose |
|---|---|
| `template-build.yaml` | Reusable build template — checkout, .NET setup, restore, build, publish, upload artifact |
| `template-deploy.yaml` | Reusable deploy template — download artifact, deploy to Azure Web App |
| `staging-build-deploy.yaml` | Caller for `staging` branch — CI → CD with concurrency group |
| `production-build-deploy.yaml` | Caller for `master` branch — CI → CD with concurrency group |

## Setup

### 1. GitHub Secrets

Go to your repository → **Settings** → **Secrets and variables** → **Actions**, and add the following secret:

| Secret | Description |
|---|---|
| `AZURE_WEB_API_PUBLISH_PROFILE` | The publish profile XML downloaded from Azure Portal for the App Service. If staging and production use different profiles, scope the secret per GitHub Environment (see step 3). |

To download a publish profile:
1. Go to [Azure Portal](https://portal.azure.com)
2. Navigate to your App Service
3. Click **Get publish profile** from the top menu
4. Copy the downloaded XML content and paste it as the secret value

### 2. Azure Web App Names

Update the `AZURE_WEB_APP_NAME` values in the caller workflows to match your actual Azure App Service names:

- `staging-build-deploy.yaml` → currently set to `motomerkado-api-staging`
- `production-build-deploy.yaml` → currently set to `motomerkado-api`

### 3. GitHub Environments (Optional but Recommended)

Create environments in your repository → **Settings** → **Environments**:

- **staging** — for staging deployments
- **production** — for production deployments

This enables:
- Deployment protection rules (e.g., required reviewers for production)
- Environment-scoped secrets (different `AZURE_WEB_API_PUBLISH_PROFILE` per environment)
- Deployment history and status tracking

### 4. Branches

Ensure the following branches exist:

- **`staging`** — pushes to this branch trigger the staging pipeline
- **`master`** — pushes to this branch trigger the production pipeline
