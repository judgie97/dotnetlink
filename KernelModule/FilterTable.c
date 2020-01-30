#define __KERNEL__
#define __MODULE__

#include "FilterTable.h"

#include <linux/netfilter.h>

struct DotNetFilterRule* filterTable = 0;
unsigned int numberOfRules = 0;
unsigned int nextRule = 1;

#define RULE_SIZE sizeof(struct DotNetFilterRule)

void destroyFilterTable(void)
{
  if(filterTable)
  {
    kfree(filterTable);
    filterTable = 0;
  }
}

int getRules(struct DotNetFilterRule** rules)
{
  *rules = filterTable;
  return numberOfRules;
}

unsigned int addRule(struct DotNetFilterRule* entry)
{
  if(!entry)
    return 0;

  int rulePosition = -1;
  if(entry->next)
  {
    int i;
    for(i = 0; i < numberOfRules; i++)
    {
      if(entry->next == filterTable[i].id)
      {
        rulePosition = i;
        break;
      }
    }
    if(rulePosition == -1)
      return 0;
  }

  struct DotNetFilterRule* newTable = kmalloc(RULE_SIZE * (numberOfRules + 1), 0);
  memcpy(newTable, filterTable, RULE_SIZE * numberOfRules);
  if(!entry->next)
  {
    memcpy(newTable + numberOfRules, entry, RULE_SIZE);
    newTable[numberOfRules].id = nextRule;
    destroyFilterTable();
    filterTable = newTable;
    numberOfRules++;

    return nextRule++;
  }

  memcpy(newTable + rulePosition, entry, RULE_SIZE);
  memcpy(newTable + rulePosition + 1, filterTable + rulePosition, RULE_SIZE * (numberOfRules - rulePosition));
  newTable[rulePosition].id = nextRule;
  newTable[rulePosition - 1].next = nextRule;

  destroyFilterTable();
  filterTable = newTable;
  numberOfRules++;

  return nextRule++;
}

unsigned int delRule(unsigned int rule)
{
  if(!filterTable)
    return 0;

  int rulePosition = -1;

  int i;
  for(i = 0; i < numberOfRules; i++)
  {
    if(rule == filterTable[i].id)
    {
      rulePosition = i;
      break;
    }
  }

  if(rulePosition == -1)
    return 0;

  if(numberOfRules == 1)
  {
    destroyFilterTable();
    numberOfRules = 0;
    return rule;
  }

  struct DotNetFilterRule* newTable = kmalloc(RULE_SIZE * (numberOfRules - 1), 0);
  memcpy(newTable, filterTable, RULE_SIZE * rulePosition);
  memcpy(newTable + rulePosition, filterTable + rulePosition, RULE_SIZE * (numberOfRules - rulePosition - 1));
  newTable[rulePosition - 1].next = newTable[rulePosition].id;

  destroyFilterTable();
  filterTable = newTable;
  numberOfRules--;
  
  return rule;
}

unsigned int ruleCount(void)
{
  return numberOfRules;
}





















