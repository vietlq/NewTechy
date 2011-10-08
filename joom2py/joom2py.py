#!/usr/bin/python

import os
import sys
import tempfile

"""
http://stackoverflow.com/questions/847850/cross-platform-way-of-getting-temp-directory-in-python

tempfile.mkdtemp
"""

class Joom2Py(object):
    def __init__(self, templatePath, destDir = None):
        self.templatePath = templatePath
        self.destDir = destDir
        self.tempDir = tempfile.mkdtemp
        
        if destDir == None:
            destDir = os.getcwd()
    
    def is_zip(self):
        return self.templatePath.endswith('.zip')
    
    def set_template_path(self, templatePath):
        self.templatePath = templatePath
    
    def template_path(self):
        return self.templatePath
    
    def set_dest_dir(self, destDir):
        self.destDir = destDir
    
    def dest_dir(self):
        return self.destDir
    
    def process_template(self):
        self.verify_template()
    
    def unzip_template(self):
        pass
    
    def verify_template(self):    
        self.isZip = self.is_zip()
        
        if not os.path.exists(self.templatePath):
            print "The template path does not exist!"
            return -1
        
        if not os.access(self.templatePath, os.R_OK):
            print "The template path is not readable!"
            return -2
        
        if self.isZip:
            self.unzip_template()
    
    def move_static(self):
        pass
    
    def replace_lang(self):
        pass
    
    def replace_head(self):
        pass
    
    def replace_css_link(self):
        pass
    
    def replace_pathway(self):
        pass
    
    def replace_site_name(self):
        pass
    
    def replace_left_module(self):
        pass
    
    def replace_main_body(self):
        pass
    
    def clear_php_tags(self):
        pass
    
    def move_index_file(self):
        pass
    
    def append_css(self):
        pass
    
    def copy_license(self):
        pass
    
    def zip_template(self):
        pass
    
    def write_template(self):
        pass

if __name__ == '__main__':
    if len(sys.argv) not in [2, 3]:
        print "Usage: %s <path_to_template> [destination_folder]" % sys.argv[0]
    
    if len(sys.argv) == 2:
        templatePath = sys.argv[1]
        destDir = None
    
    if len(sys.argv) == 3:
        templatePath = sys.argv[1]
        destDir = sys.argv[2]
    
    joom2pyObj = Joom2Py(sys.argv[1], destDir)
    joom2pyObj.process_template()
