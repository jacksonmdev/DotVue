
# Vue Base Enterprise Documentation

Welcome to the **Vue Base Enterprise** project! This documentation provides an overview of the project's structure, setup instructions, and guidelines for contributing.

## Table of Contents

1. [Project Overview](#project-overview)
2. [Folder Structure](#folder-structure)
3. [Modules Directory](#modules-directory)
4. [Atomic Design Principles](#atomic-design-principles)
5. [Getting Started](#getting-started)
6. [Development](#development)
7. [Building for Production](#building-for-production)
8. [Linting and Formatting](#linting-and-formatting)
9. [Contributing](#contributing)
10. [License](#license)

## 1. Project Overview

**Vue Base Enterprise** is an opinionated boilerplate for building enterprise-level applications using [Vue 3](https://vuejs.org/), [Quasar](https://quasar.dev/), and [Vite](https://vitejs.dev/). It incorporates a modular architecture and adheres to **Atomic Design principles**, allowing for scalable and maintainable codebases.

## 2. Folder Structure

The project's folder structure is organized as follows:

```plaintext
vue-base-enterprise/
├── .husky/                 # Git hooks configuration
├── public/                 # Static assets
├── src/                    # Source code
│   ├── assets/             # Project assets (e.g., images, styles)
│   ├── components/         # Global reusable components
│   ├── layouts/            # Layout components
│   ├── modules/            # Feature-specific modules
│   ├── pages/              # Page components
│   ├── router/             # Vue Router configuration
│   ├── store/              # Vuex store configuration
│   ├── utils/              # Utility functions
│   ├── App.vue             # Root component
│   └── main.ts             # Entry point
├── .env                    # Environment variables for development
├── .env.prod               # Environment variables for production
├── .env.qa                 # Environment variables for QA
├── .gitignore              # Git ignore rules
├── .prettierrc             # Prettier configuration
├── commitlint.config.ts    # Commitlint configuration
├── eslint.config.js        # ESLint configuration
├── index.html              # Main HTML template
├── package.json            # NPM dependencies and scripts
├── tsconfig.json           # TypeScript configuration
├── tsconfig.node.json      # TypeScript configuration for Node
└── vite.config.ts          # Vite configuration
```

## 3. Modules Directory

The `modules/` directory is designed to encapsulate all components, scripts, and assets related to a specific feature. This isolation promotes a clear separation of concerns and enhances maintainability.

Each module typically follows this structure:

```plaintext
modules/
└── feature-name/
    ├── components/         # Feature-specific components
    ├── store/              # Vuex modules or Pinia stores
    ├── routes.ts           # Route definitions for the feature
    ├── types.ts            # TypeScript types and interfaces
    └── index.ts            # Entry point for the module
```

## 4. Atomic Design Principles

This project embraces **Atomic Design principles** to create a consistent and scalable UI architecture. Atomic Design breaks down the UI into the following hierarchical levels:

- **Atoms**: Basic building blocks such as buttons, input fields, or icons.
- **Molecules**: Groups of atoms that function together, such as a form input with a label.
- **Organisms**: Larger components composed of molecules and/or atoms, such as a navigation bar.
- **Templates**: Page-level structures that define the layout without specific content.
- **Pages**: Fully realized pages with real content, ready to be rendered.

The `src/components/` folder reflects this structure:

```plaintext
src/components/
├── atoms/             # Small, reusable elements
├── molecules/         # Combinations of atoms
├── organisms/         # Complex UI components
├── templates/         # Structural components for pages
└── pages/             # Fully rendered pages
```

This approach ensures UI consistency and makes it easier to reuse components throughout the application.

## 5. Getting Started

### Prerequisites

Ensure you have the following installed:

- [Node.js](https://nodejs.org/) (version 14 or higher)
- [npm](https://www.npmjs.com/) or [Yarn](https://yarnpkg.com/)

### Installation

1. **Clone the repository:**

   ```bash
   git clone https://github.com/jacksonmdev/vue-base-enterprise.git
   ```

2. **Navigate to the project directory:**

   ```bash
   cd vue-base-enterprise
   ```

3. **Install dependencies:**

   Using npm:

   ```bash
   npm install
   ```

   Or using Yarn:

   ```bash
   yarn install
   ```

## 6. Development

To start the development server with hot module replacement:

Using npm:

```bash
npm run dev
```

Or using Yarn:

```bash
yarn dev
```

The application will be accessible at `http://localhost:3000`.

## 7. Building for Production

To build the project for production:

Using npm:

```bash
npm run build
```

Or using Yarn:

```bash
yarn build
```

The optimized files will be generated in the `dist/` directory.

## 8. Linting and Formatting

This project uses [ESLint](https://eslint.org/) for linting and [Prettier](https://prettier.io/) for code formatting.

- **Linting:** To run ESLint:

  Using npm:

  ```bash
  npm run lint
  ```

  Or using Yarn:

  ```bash
  yarn lint
  ```

- **Formatting:** Prettier is configured to format code on commit via Husky hooks.

## 9. Contributing

Contributions are welcome! Please follow these steps:

1. **Fork the repository.**
2. **Create a new branch:**

   ```bash
   git checkout -b feature/your-feature-name
   ```

3. **Make your changes.**
4. **Commit your changes:**

   ```bash
   git commit -m 'Add some feature'
   ```

5. **Push to the branch:**

   ```bash
   git push origin feature/your-feature-name
   ```

6. **Open a pull request.**

## 10. License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

For more information, please refer to the [repository](https://github.com/jacksonmdev/vue-base-enterprise).
