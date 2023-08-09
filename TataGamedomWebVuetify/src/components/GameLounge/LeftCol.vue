<template>
  <v-col cols="12" sm="2">
    <v-sheet rounded="lg" min-height="268">
      <v-list :items="items" item-props lines="two" rounded="lg">
        <template v-slot:subtitle="{ subtitle }">
          <div v-html="subtitle"></div>
        </template>
      </v-list>
    </v-sheet>
  </v-col>
</template>
<script setup>
import { ref } from "vue";
const items = ref([
  { type: "subheader", title: "熱門趨勢" },
  {
    title: "Brunch this weekend?",
    subtitle: `<span class="text-primary">Ali Connors</span> &mdash; I'll be in your neighborhood doing errands this weekend. Do you want to hang out?`,
  },
  { type: "divider" },
  {
    title: "Summer BBQ",
    subtitle: `<span class="text-primary">to Alex, Scott, Jennifer</span> &mdash; Wish I could come, but I'm out of town this weekend.`,
  },
  { type: "divider" },
  {
    title: "Oui oui",
    subtitle:
      '<span class="text-primary">Sandra Adams</span> &mdash; Do you have Paris recommendations? Have you ever been?',
  },
  { type: "divider" },
  {
    title: "Birthday gift",
    subtitle:
      '<span class="text-primary">Trevor Hansen</span> &mdash; Have any ideas about what we should get Heidi for her birthday?',
  },
  { type: "divider" },
  {
    title: "Recipe to try",
    subtitle:
      '<span class="text-primary">Britta Holt</span> &mdash; We should eat this: Grate, Squash, Corn, and tomatillo Tacos.',
  },
]);
</script>
<style scoped></style>
