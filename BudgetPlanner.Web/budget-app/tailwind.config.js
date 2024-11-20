/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts}"],
  theme: {
    extend: {
      fontFamily: {
        inter: ["Inter", "serif"],
      },
    },
  },
  plugins: [require("daisyui"), require("@tailwindcss/forms")],
};
