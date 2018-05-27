using System;
using System.Collections.Generic;
using System.Text;

namespace ForwardChaining {
    public class Rule {
        private readonly List<char> _antecedent;
        private readonly List<char> _consequent;
        private readonly int _number;

        private bool _isUsed;

        public Rule(string rule, int number) {
            _number = number;
            _isUsed = false;
            _antecedent = new List<char>();
            _consequent = new List<char>();
            StringToRule(rule);
        }

        public int GetNumber() {
            return _number;
        }

        private void StringToRule(string rule) {
            bool isAntecedent = true;
            foreach (char c in rule) {

                if (c == '>') {
                    isAntecedent = false;
                }

                if (Char.IsLetter(c)) {

                    char letter = Char.ToUpper(c);

                    if (letter != 'R') {
                        if (isAntecedent == true) {
                            _antecedent.Add(letter);
                        }
                        else {
                            _consequent.Add(letter);
                        }
                    }
                }
            }
        }

        public string GetRule() {
            string rule = "";
            foreach (var letter in _antecedent) {
                rule += letter + " ";
            }
            rule += "-> ";
            foreach (var letter in _consequent) {
                rule += letter + " ";
            }
            return rule;
        }

        public List<char> GetAntecedent() {
            return _antecedent;
        }

        public List<char> GetConsequent() {
            return _consequent;
        }

        public bool GetIsUsed() {
            return _isUsed;
        }

        public void SetIsUsed(bool isUsed) {
            _isUsed = isUsed;
        }
    }
}