module.exports = {
  root: true,
  env: {
    node: true,
  },
  parser: "@typescript-eslint/parser",
  plugins: ["@typescript-eslint"],

  extends: [
    "plugin:vue/vue3-essential",
    "eslint:recommended",
    "plugin:@typescript-eslint/recommended",
  ],
};
