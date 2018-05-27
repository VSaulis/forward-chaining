using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ForwardChaining {
    public class ForwardChaining {
        private readonly List<Rule> _rules;
        private readonly List<char> _facts;
        private readonly List<Rule> _usedRules;
        private char _goal;
        private int _step;

        public ForwardChaining(string filename) {
            _step = 0;
            _usedRules = new List<Rule>();
            _rules = new List<Rule>();
            _facts = new List<char>();
            ReadFile(filename);
        }

        public bool Iterate() {
            if (_facts.Contains(_goal)) {
                return true;
            }

            foreach (Rule rule in _rules) {
                if (!rule.GetIsUsed()) {
                    if (!rule.GetAntecedent().Except(_facts).Any()) {
                        rule.SetIsUsed(true);
                        int changes = 0;
                        foreach (char letter in rule.GetConsequent()) {
                            if (!_facts.Contains(letter)) {
                                changes++;
                                _facts.Add(letter);
                            }
                        }
                        if (changes == 0) {
                            _step++;
                            Log.AddToLog(_step + ". Rule used : R" + rule.GetNumber() + ". Result : " +
                                         "Rule not return new facts.");
                        }
                        else {
                            _step++;
                            _usedRules.Add(rule);
                            Log.AddToLog(_step + ". Rule used : R" + rule.GetNumber() + ". Result : " +
                                         "Rule return new facts : " + new string(rule.GetConsequent().ToArray()));
                            rule.SetIsUsed(false);
                        }
                        return Iterate();
                    }
                    else {
                        _step++;
                        Log.AddToLog(_step + ". Rule used : R" + rule.GetNumber() + ". Result : " + "Rule antisedent not match facts.");
                    }
                }
                else {
                    _step++;
                    Log.AddToLog(
                        _step + ". Rule used : R" + rule.GetNumber() + ". Result : " + "Rule was already used.");
                }
            }
            return false;
        }

        public List<Rule> GetUserRules() {
            return _usedRules;
        }

        private void ReadFile(string filename) {
            string status = "";
            int ruleNumber = 0;

            List<string> lines = File.ReadAllLines(filename).ToList();
            foreach (var line in lines) {
                if (line.Contains("Rules")) {
                    status = "Rules";
                }
                else if (line.Contains("Facts")) {
                    status = "Facts";
                }
                else if (line.Contains("Goal")) {
                    status = "Goal";
                }
                else {
                    if (status == "") {
                        Console.WriteLine("Wrong file");
                        return;
                    }

                    if (status == "Rules") {
                        if (!String.IsNullOrEmpty(line)) {
                            ruleNumber++;
                            Rule rule = new Rule(line, ruleNumber);
                            _rules.Add(rule);
                        }
                    }
                    else if (status == "Facts") {
                        foreach (char c in line)
                            if (Char.IsLetter(c)) {
                                char letter = Char.ToUpper(c);
                                _facts.Add(letter);
                            }
                    }
                    else if (status == "Goal") {
                        foreach (char c in line)
                            if (Char.IsLetter(c)) {
                                char letter = Char.ToUpper(c);
                                _goal = letter;
                            }
                    }
                    else {
                        Console.WriteLine("Wrong file");
                        return;
                    }
                }
            }
        }
    }
}